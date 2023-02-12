using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using Infra.Ef.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Repository
{
    public class WalletRespository : EfRepository<Wallet>, IWalletRespository
    {
        public WalletRespository(DbContext context) : base(context)
        {
        }

        public Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumTypeActives enumTypeActives)
        {
            return null;
        }
    }
}
