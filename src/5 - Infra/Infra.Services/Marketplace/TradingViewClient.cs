using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Infra.Services.Marketplace.Dtos;
using Infra.Services.Resources;
using System.Text.Json;

namespace Infra.Services.Marketplace
{
    public class TradingViewClient : IMarketplaceService
    {
        public string Url => "https://symbol-search.tradingview.com/symbol_search/v3/";

        public Task<dynamic> GetAsync(string ticker)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetPriceAsync(string ticker)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> FindAllTickers(string ticker, EnumTypeActives enumTypeActives = EnumTypeActives.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            string type = enumTypeActives switch
            {
                EnumTypeActives.FIIS or EnumTypeActives.REITS => "fund",
                EnumTypeActives.ACTION or EnumTypeActives.STOCKES => "stock",
                EnumTypeActives.ALL => "undefined",
                _ => "undefined",
            };

            var uri = $"{Url}?text={ticker}&hl=1&exchange={exchange}&country=BR&lang=pt&search_type={type}&domain=production&sort_by_country=BR";

            using var client = new HttpClient();
            var json = await client.GetStringAsync(uri);

            if (string.IsNullOrEmpty(json)) throw new HttpRequestException($"result {Messages.NotFound}");

            var tradingViewRoot = JsonSerializer.Deserialize<TradingViewRoot>(json);

            if (tradingViewRoot == null) throw new JsonException($"result tradingViewRoot {Messages.NotFound}");

            return await Task.FromResult(tradingViewRoot.ToList());
        }
    }
}
