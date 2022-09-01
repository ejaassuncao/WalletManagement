using System;

namespace Domain.Core.Model.Actives
{
    public sealed class Reits : AbstractActives
    {
        public Reits(Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(company, ticker, amount, unitCost, dateBuy)
        {
        }

        public Reits(int id, Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(id, company, ticker, amount, unitCost, dateBuy)
        {
        }

        public override TypeActives TypeActives => TypeActives.Reits;
    }
}
