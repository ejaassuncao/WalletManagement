using Domain.Core.Enumerables;
using Domain.Models.Interfaces;
using Infra.Services.Marketplace.Dtos;
using Infra.Services.Resources;
using Newtonsoft.Json;

namespace Infra.Services.Marketplace.Plugins
{
    internal class BrApi
    {
        private readonly IBrApiConfiguration _brApiConfiguration;
        public BrApi(IBrApiConfiguration brApiConfiguration)
        {
            _brApiConfiguration = brApiConfiguration;
        }

        public async Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.NYSE)
        {           
            var uri = new Uri($"https://brapi.dev/api/quote/{ticker}?token={_brApiConfiguration.Token}&range=1d&interval=1d&fundamental=false&dividends=false");

            using var client = new HttpClient();
            var json = await client.GetStringAsync(uri);

            if (string.IsNullOrEmpty(json)) throw new HttpRequestException($"result {Messages.NotFound}");
                       
            var brApiDtoRoot = JsonConvert.DeserializeObject<BrApiDtoRoot>(json);

            if (brApiDtoRoot == null || brApiDtoRoot?.Results ==null || brApiDtoRoot?.Results.Count==0) throw new Exception("result tradingViewRoot {Messages.NotFound}");


            return brApiDtoRoot.Results[0].RegularMarketPrice;
        }
    }
}
