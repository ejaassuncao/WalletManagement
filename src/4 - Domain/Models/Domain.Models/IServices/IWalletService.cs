﻿using Domain.Core.Dto;
using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using Domain.Models.Dto;
using Service.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.IServices
{
    public interface IWalletService
    {
        IEnumerable<TotalPriceTypeActivesDto> GetTotalPriceTypeActives(Wallet wallat);
        Task<IEnumerable<TotalPriceTypeActivesDto>> GetTotalPriceTypeActivesAsync(int id);
        Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives);
        Task Insert(ActiveDto dto);
        Task RefleshActiveAsync();
        Task<IEnumerable<ItemList>> GetActive(string ticker);
    }
}
