using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Infra.Services.Resources;
using YahooFinanceApi;

namespace Infra.Services.Marketplace
{
    public class YahooFinanceClient : IMarketplaceService
    {
        public string Url => "using API Yahoo Finance";

        public async Task<dynamic> GetPriceAsync(string ticker)
        {
            // You could query multiple symbols with multiple fields through the following steps:
            string addSymbol = "%2C";
            var securities = await Yahoo.Symbols($"{ticker}").Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync();
            if (securities.Count == 0) throw new Exception($"{Messages.Active} {Messages.NotFound}");

            var action = securities[ticker];
            var price = action[Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value

            return price;
        }

        public async Task<dynamic> GetAsync(string ticker)
        {
            // You could query multiple symbols with multiple fields through the following steps:
            var securities = await Yahoo.Symbols(ticker).Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync();
            return securities;
        }

        public Task<string> FindAllTickers(string ticker)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> FindAllTickers(string ticker, EnumTypeActives enumTypeActives = EnumTypeActives.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            throw new NotImplementedException();
        }
    }
}
