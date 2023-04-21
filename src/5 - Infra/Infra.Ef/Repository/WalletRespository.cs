using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using Infra.Ef.Context;

namespace Infra.Ef.Repository
{
    public class WalletRespository : EfRepository<Wallet>, IWalletRespository
    {
        public WalletRespository(AppDBContext context) : base(context)
        {
        }

        public Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives)
        {
            throw new NotImplementedException();
        }
    }
}
