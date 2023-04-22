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
        public WalletRespository(AppDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives)
        {
            var query = context.TbActivesOfCompanys.Include(x => x.Active)
                .ThenInclude(a => a.Company)
                .ThenInclude(c => c.Setor);

            if (enumTypeActives != EnumCategory.ALL)
                query.Where(x => enumTypeActives.Equals(x.Active.Category));

            return await query
                   .Select(x => new PortifolioDto
                   {
                       Category = x.Active.Category.ToString("g"),
                       Sector = x.Active.Company.Setor.Name,
                       Ticker = x.Active.Ticker,
                       Amount = x.Amount,
                       Price = x.Active.Price,
                       UnitCost = x.UnitCost,
                       TotalCost = x.Amount * x.UnitCost,
                       TotalPrice = x.Amount * x.Active.Price,
                       LP = (x.Amount * x.Active.Price) - (x.Amount * x.UnitCost)
                   }).ToListAsync();
        }
    }
}
