using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using Infra.Ef.Context;
using Infra.Ef.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Repository
{
    public class WalletRespository : EfRepository<Wallet>, IWalletRespository
    {
        public WalletRespository(AppDBContext context, IMapper mapper) : base(context, mapper) { }       

        public async Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives)
        {
            var query = _context.TbActivesOfCompanys.Include(x => x.Active)
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

        public async Task<List<Actions>> GetTickersAsync()
        {           
            return await _context.TbActives.ProjectTo<Actions>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task UpdateTickerAsync(List<Actions> tickers)
        {
            foreach (var action in tickers)
            {
                var data = _mapper.Map<TbActive>(action);
                _context.TbActives.Update(data);
            }

            await _context.SaveChangesAsync();
        }
    }
}
