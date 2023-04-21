using Domain.Core.Enumerables;
using Domain.Core.Model.Enumerables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IMarketplaceService
    {
        public Task<dynamic> GetPriceAsync(string ticker, EnumExchanges exchange = EnumExchanges.NYSE);       
        public Task<IEnumerable<string>> FindAllTickers(string ticker, EnumCategory enumTypeActives = EnumCategory.ALL, EnumExchanges exchange = EnumExchanges.ALL);
    }
}
