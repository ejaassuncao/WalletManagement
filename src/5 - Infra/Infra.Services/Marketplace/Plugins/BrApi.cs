using Domain.Core.Enumerables;
using Infra.Services.Marketplace.Dtos;
using Infra.Services.Resources;
using System.Text.Json;

namespace Infra.Services.Marketplace.Plugins
{
    internal class BrApi
    {       
        public async Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.NYSE)
        {
             var uri = new Uri($"https://brapi.dev/api/quote/{ticker}?range=1d&interval=1d&fundamental=false&dividends=false");

            using var client = new HttpClient();
            var json = await client.GetStringAsync(uri);

            if (string.IsNullOrEmpty(json)) throw new HttpRequestException($"result {Messages.NotFound}");

            var brApiDtoRoot = JsonSerializer.Deserialize<BrApiDtoRoot>(json);

            if (brApiDtoRoot == null || brApiDtoRoot?.Results ==null || brApiDtoRoot?.Results.Count==0) throw new JsonException($"result tradingViewRoot {Messages.NotFound}");


            return brApiDtoRoot.Results[0].RegularMarketPrice;
        }
    }
}
