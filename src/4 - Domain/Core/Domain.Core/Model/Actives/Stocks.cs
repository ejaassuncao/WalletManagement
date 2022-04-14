using System;

namespace Domain.Core.Model.Actives
{
    /// <summary>
    /// Ativos
    /// </summary>
    public sealed class Stocks : AbstractActives
    {
        public Stocks(Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(company, ticker, amount, unitCost, dateBuy)
        {
        }

        public Stocks(int id, Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(id, company, ticker, amount, unitCost, dateBuy)
        {
        }

        public override TypeActives TypeActives => TypeActives.Stockes;

    }
}