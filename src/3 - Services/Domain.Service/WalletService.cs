using Domain.Core.Model;
using Domain.Core.Model.Enumerables;
using System;
using System.Collections.Generic;

namespace Service.Core
{
    public sealed class WalletService
    {    
        /// <summary>
        /// Visualizar valor total investidos em Grupos de ativos
        /// Posso ver em percentual ou preço
        /// </summary>
        public IEnumerable<TotalPriceTypeActives> GetTotalPriceTypeActives(Wallet wallat)
        {           
            List<TotalPriceTypeActives> totalprice =  new List<TotalPriceTypeActives>();

            double valueTotal = wallat.TotalCost();
            foreach (EnumTypeActives typeActives in (EnumTypeActives[])Enum.GetValues(typeof(EnumTypeActives)))
            {
                var valueUnit = wallat.TotalCost(typeActives);
                totalprice.Add(new TotalPriceTypeActives
                {
                    TypeActives = typeActives,
                    TotalCost   = valueUnit,
                    TotalCostPercent = (valueUnit / valueTotal) * 100
                }); ;
            };

            return totalprice;
        }

    }
}
