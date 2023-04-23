﻿using Domain.Commons.IRepository;
using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.core.IRepository
{
    public interface IWalletRespository : IRepository<Wallet>
    {
        Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives);
        Task<List<Actions>> GetTickersAsync();
        Task UpdateTickerAsync(List<Actions> tickers);
    }
}
