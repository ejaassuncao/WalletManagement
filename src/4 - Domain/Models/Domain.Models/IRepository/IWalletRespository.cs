using Domain.Commons.Entity;
using Domain.Commons.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.core.IRepository
{
    public interface IWalletRespository : IRepository<Wallet>
    {
        Task<Broker> GetByIdBrokerAsync(Guid guid);
        Task<User> GetByIdUsuarioAsync(Guid id);
        Task<Wallet> GetByIdWalletAsync(Guid guid);
        Task<Actions> GetByTickerActionAsync(string ticker);
        Task<Company> GetByTickerCompanyAsync(string nameCompany);
        Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives);
        Task<List<Actions>> GetTickersAsync();
        Task InsertActionsAsync(Actions action);
        Task InsertCompanyAsync(Company companyNew);
        Task UpdateTickerAsync(List<Actions> tickers);
    }
}
