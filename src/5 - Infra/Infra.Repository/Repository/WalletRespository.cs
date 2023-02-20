using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using Infra.Repository.Context;

namespace Infra.Repository.Repository
{
    public class WalletRespository : EfRepository<Wallet>, IWalletRespository
    {
        public WalletRespository(DataBaseContext context) : base(context)
        {
        }

        public Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumTypeActives enumTypeActives)
        {
            throw new NotImplementedException();
        }
    }
}
