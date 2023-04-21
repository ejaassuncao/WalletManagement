using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Enumerables;
using Infra.Services.Marketplace;
using System.Threading.Tasks;
using Xunit;

namespace Infra.Services.Test
{
    public class MarketplaceClientTest
    {
        private readonly IMarketplaceService _marketplaceService;

        public MarketplaceClientTest()
        {
            _marketplaceService = new MarketplaceClient();
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
        public async Task FindAllTickers(string ticker)
        {
            var json = await _marketplaceService.FindAllTickers(ticker, EnumCategory.ACTION, EnumExchanges.BMFBOVESPA);

            Assert.NotNull(json);
        }

        /// <summary>
        /// Quero pegar o preço de uma ação ao passar o Ticker
        /// </summary>
        [Theory]
        [InlineData("CPLE3")]
        [InlineData("MGLU3")]
        [InlineData("TAEE11")]
        public async Task GetPriceAsync(string ticker)
        {
            var price = await _marketplaceService.GetPriceAsync(ticker, EnumExchanges.BMFBOVESPA);

            Assert.True(price > 0);
        }
    }
}
