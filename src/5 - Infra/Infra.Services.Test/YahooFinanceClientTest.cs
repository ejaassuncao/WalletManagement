using Domain.Core.Interfaces;
using Infra.Services.Marketplace;
using System.Threading.Tasks;
using Xunit;

namespace Infra.Services.Test
{
    public class YahooFinanceClientTest
    {
        private readonly IMarketplaceService _marketplaceService;
        public YahooFinanceClientTest()
        {
            _marketplaceService = new YahooFinanceClient();
        }
        
        /// <summary>
        /// Quero pegar o preço de uma ação ao passar o Ticker
        /// </summary>
        [Theory]       
        [InlineData("CPLE6.SA")]
        public async Task CheckResponseGetActionAsync(string ticker)
        {
            var action = await _marketplaceService.GetPriceAsync(ticker);

            Assert.NotNull(action);
        }
    }
}