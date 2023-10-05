using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Domain.Models.Dto;
using Domain.Models.Settings;
using Infra.Services.Marketplace.Plugins;
using Microsoft.Extensions.Options;

namespace Infra.Services.Marketplace
{
    public class MarketplaceClient : IMarketplaceService
    {
        private readonly Settings _settings;

        public MarketplaceClient(Settings  settings)
        {
            this._settings = settings;
        }

        public async Task<IEnumerable<string>> FindAllTickersAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            return await new TradingView().FindAllTickersAsync(ticker, enumTypeActives, exchange);
        }

        public async Task<IEnumerable<ItemList>> FindAllTickersItemListAsync(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            return await new TradingView().FindAllTickersItemListAsync(ticker, enumTypeActives, exchange);
        }

        public async Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.ALL)
        {
            //return new YahooFinance().GetPriceAsync(ticker, exchange); //depreciado
            return await new Plugins.BrApi(_settings.BrApi).GetPriceAsync(ticker, exchange);
        }

    }
}
