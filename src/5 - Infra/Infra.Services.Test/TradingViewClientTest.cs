using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Infra.Services.Marketplace;
using System.Threading.Tasks;
using Xunit;

namespace Infra.Services.Test
{
    public class TradingViewClientTest
    {
        private readonly IMarketplaceService _marketplaceService;

        public TradingViewClientTest()
        {
            _marketplaceService = new TradingViewClient();
        }

        /// <summary>
        /// Quero pegar começar a digitar uma ação e Pegar uma lista
        /// </summary>
        [Theory]
        [InlineData("C")]
        [InlineData("CP")]
        [InlineData("CPL")]
        [InlineData("CPLE")]
        [InlineData("CPLE6")]
        public async Task GetListTicker(string ticker)
        {
            var json = await _marketplaceService.FindAllTickers(ticker, EnumTypeActives.ACTION, EnumExchanges.BMFBOVESPA);

            Assert.NotNull(json);
        }
    }
}
