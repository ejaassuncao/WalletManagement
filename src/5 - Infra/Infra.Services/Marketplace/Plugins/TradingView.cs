using Domain.Core.Enumerables;
using Domain.Core.Model.Enumerables;
using Domain.Models.Dto;
using Infra.Services.Marketplace.Dtos;
using Infra.Services.Resources;
using System.Text.Json;

namespace Infra.Services.Marketplace.Plugins
{
    internal class TradingView
    {
        private const string uriBase = "https://symbol-search.tradingview.com/symbol_search/v3/";

        private async Task<TradingViewRoot> ExecuteGetAPI(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {

            string type = enumTypeActives switch
            {
                EnumCategory.FIIS or EnumCategory.REITS => "fund",
                EnumCategory.ACTION or EnumCategory.STOCKES => "stock",
                EnumCategory.ALL => "undefined",
                _ => "undefined",
            };


            var uri = $"{uriBase}?text={ticker}&hl=1&exchange={exchange}&country=BR&lang=pt&search_type={type}&domain=production&sort_by_country=BR";

            using var client = new HttpClient();
            var json = await client.GetStringAsync(uri);

            if (string.IsNullOrEmpty(json)) throw new HttpRequestException($"result {Messages.NotFound}");

            var tradingViewRoot = JsonSerializer.Deserialize<TradingViewRoot>(json);

            if (tradingViewRoot == null) throw new JsonException($"result tradingViewRoot {Messages.NotFound}");

            return tradingViewRoot;
        }

        public async Task<IEnumerable<string>> FindAllTickersAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            var tradingViewRoot = await ExecuteGetAPI(ticker, enumTypeActives, exchange);
            return await Task.FromResult(tradingViewRoot.ToList());
        }

        public async Task<IEnumerable<ItemList>> FindAllTickersItemListAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            var tradingViewRoot = await ExecuteGetAPI(ticker, enumTypeActives, exchange);
            return tradingViewRoot.ToItemList();
        }
    }
}