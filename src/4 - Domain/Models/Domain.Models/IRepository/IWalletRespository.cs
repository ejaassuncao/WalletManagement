using Domain.Commons.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.core.IRepository
{
    public interface IWalletRespository : IRepository<Wallet>
    {
        Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives);
    }
}
