﻿using Domain.Core.Enumerables;
using Infra.Services.Resources;
using YahooFinanceApi;

namespace Infra.Services.Marketplace.Plugins
{
    internal class YahooFinance
    {
        public async Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.NYSE)
        {
            // You could query multiple symbols with multiple fields through the following steps:
            if (exchange == EnumExchanges.BMFBOVESPA)
            {
                ticker += ".SA";
                return GetPriceAsync(ticker);
            }

            var securities = await Yahoo.Symbols($"{ticker}").Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync();
            if (securities.Count == 0) throw new Exception($"{Messages.Active} {Messages.NotFound}");

            var action = securities[ticker];
            var price = action[Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value

            return price;
        }
    }
}