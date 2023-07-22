using Domain.Commons.Entity;
using Domain.core.IRepository;
using Domain.Core.Dto;
using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.IServices;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using Domain.Models.Dto;
using Service.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Core.Services
{
    public sealed class WalletService : IWalletService
    {
        private readonly IWalletRespository _walletRespository;
        private readonly IMarketplaceService _marketplaceService;

        public WalletService(IWalletRespository walletRespository, IMarketplaceService marketplaceService)
        {
            this._walletRespository = walletRespository;
            this._marketplaceService = marketplaceService;
        }

        public async Task<IEnumerable<PortifolioDto>> GetPortifolioAsync(EnumCategory enumTypeActives)
        {
            return await _walletRespository.GetPortifolioAsync(enumTypeActives);
        }

        public async Task RefleshActiveAsync()
        {
            List<Actions> actions = await _walletRespository.GetTickersAsync();

            foreach (Actions action in actions)
            {
                try 
                { 
                    var price = await this._marketplaceService.GetPriceAsync(action.Ticker, EnumExchanges.BMFBOVESPA);                   
                    action.UpdatePrice(Convert.ToDecimal(price));

                    action.SetLastUpdate(DateTime.Now);
                    action.SetUserLastUpdate(action.UserCreated);
                }
                catch{ }

                await Task.Delay(1000);
            }

            await _walletRespository.UpdateTickerAsync(actions);
        }

        public async Task<IEnumerable<ItemList>> GetActive(string ticker)
        {
            return await _marketplaceService.FindAllTickersItemListAsync(ticker, EnumCategory.ACTION, EnumExchanges.BMFBOVESPA);
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
            var wallat = await _walletRespository.GetByIdAsync(id);
            return GetTotalPriceTypeActives(wallat);
        }

        public async Task Insert(ActiveDto dto)
        {
            User user = await _walletRespository.GetByIdUsuarioAsync(Guid.Parse("4DD0C335-6A75-49FD-B2AD-E0B6DDBB2435"));
            Wallet wallet = await _walletRespository.GetByIdWalletAsync(Guid.Parse("4DD0C335-6A75-49FD-B2AD-E0B6DDBB2435"));
            Broker broker = await _walletRespository.GetByIdBrokerAsync(Guid.Parse("3F936455-E4CB-4887-8A4C-F2F6389F9837"));
            Company company = await _walletRespository.GetByTickerCompanyAsync(dto.NameCompany);

            //cadastra compania
            if (company == null)
            {
                Guid idcompany = Guid.NewGuid();
                company = new Company(idcompany, dto.NameCompany, new List<string> { dto.Ticker });
                await _walletRespository.InsertCompanyAsync(company);
            }

            Actions action = await _walletRespository.GetByTickerActionAsync(dto.Ticker);

            if (action == null)
            {
                Guid idaction = Guid.NewGuid();
                action = new Actions(idaction, company, dto.Ticker);
                await _walletRespository.InsertActionsAsync(action);
            }

            if(dto.Operation == EnumOperationWallet.BUY)
                wallet.Buy(action, dto.Amount, dto.UnitCost, dto.Date, user, broker);
            else
                wallet.Sell(action, dto.Amount, dto.UnitCost, dto.Date, user);


            await _walletRespository.InsertAsync(wallet);           

        }
    }
}
