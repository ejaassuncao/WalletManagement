using Domain.Core.Enumerables;
using Domain.Core.Model.Enumerables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IMarketplaceService
    {
        public string Url { get; }
        public Task<dynamic> GetPriceAsync(string ticker);
        public Task<dynamic> GetAsync(string ticker);
        public Task<IEnumerable<string>> FindAllTickers(string ticker, EnumTypeActives enumTypeActives = EnumTypeActives.ALL, EnumExchanges exchange = EnumExchanges.ALL);
    }
}
