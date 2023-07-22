using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Domain.Models.Dto;
using Infra.Services.Marketplace.Plugins;

namespace Infra.Services.Marketplace
{
    public class MarketplaceClient : IMarketplaceService
    {
        public Task<IEnumerable<string>> FindAllTickersAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            return new TradingView().FindAllTickersAsync(ticker, enumTypeActives, exchange);
        }

        public Task<IEnumerable<ItemList>> FindAllTickersItemListAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            return new TradingView().FindAllTickersItemListAsync(ticker, enumTypeActives, exchange);
        }

        public Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.ALL)
        {
            //return new YahooFinance().GetPriceAsync(ticker, exchange); //depreciado
            return new BrApi().GetPriceAsync(ticker, exchange);
        }

    }
}
