using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using Service.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Service.Core.Services
{
    public sealed class WalletService
    {
        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou preço
        /// </summary>
        public IEnumerable<TotalPriceTypeActivesDto> GetTotalPriceTypeActives(Wallet wallat)
        {
            List<TotalPriceTypeActivesDto> totalprice = new List<TotalPriceTypeActivesDto>();

            double valueTotal = wallat.TotalCost();
            foreach (EnumTypeActives typeActives in (EnumTypeActives[])Enum.GetValues(typeof(EnumTypeActives)))
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


    }
}
