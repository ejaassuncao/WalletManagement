using Domain.Core.Model;
using Domain.Core.Model.Actives;
using System;
using System.Collections.Generic;
using System.Linq;

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
            foreach (TypeActives typeActives in (TypeActives[])Enum.GetValues(typeof(TypeActives)))
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
