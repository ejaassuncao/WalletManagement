using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.IServices;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using Service.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Core.Services
{
    public sealed class WalletService : IWalletService
    {
        private readonly IWalletRespository walletRespository;
        private readonly IMarketplaceService marketplaceService;

        public WalletService(IWalletRespository walletRespository, IMarketplaceService marketplaceService)
        {
            this.walletRespository = walletRespository;
            this.marketplaceService = marketplaceService;
        }

        public async Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives)
        {
            return await walletRespository.GetPortifolioAsync(enumTypeActives);
        }

        public async Task RefleshActiveAsync()
        {
            List<Actions> actions = await walletRespository.GetTickersAsync();

            foreach (Actions action in actions)
            {
                try 
                { 
                    var price = await this.marketplaceService.GetPriceAsync(action.Ticker, EnumExchanges.BMFBOVESPA);                   
                    action.UpdatePrice(Convert.ToDecimal(price));

                    action.SetLastUpdate(DateTime.Now);
                    action.SetUserLastUpdate(action.UserCreated);
                }
                catch{ }

                await Task.Delay(1000);
            }

            await walletRespository.UpdateTickerAsync(actions);
        }


        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou preço
        /// </summary>
        public IEnumerable<TotalPriceTypeActivesDto> GetTotalPriceTypeActives(Wallet wallat)
        {
            var totalprice = new List<TotalPriceTypeActivesDto>();

            decimal valueTotal = wallat.TotalCost();
            foreach (EnumCategory typeActives in (EnumCategory[])Enum.GetValues(typeof(EnumCategory)))
            {
                var valueUnit = wallat.TotalCost(typeActives);

                totalprice.Add(new TotalPriceTypeActivesDto
                {
                    TypeActives = typeActives,
                    TotalCost = valueUnit,
                    TotalCostPercent = valueUnit / valueTotal * 100
                }); ;
            };

            return totalprice;
        }

        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou preço
        /// </summary>
        public async Task<IEnumerable<TotalPriceTypeActivesDto>> GetTotalPriceTypeActivesAsync(int id)
        {
            var wallat = await walletRespository.GetByIdAsync(id);
            return GetTotalPriceTypeActives(wallat);
        }

        public async Task Insert(PortifolioDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
