using System;

namespace Domain.Core.Model.Actives
{
    public sealed class Actions : AbstractActives
    {
        public Actions(Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(company, ticker, amount, unitCost, dateBuy)
        {
        }

        public Actions(int id, Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(id, company, ticker, amount, unitCost, dateBuy)
        {
        }

        public override TypeActives TypeActives => TypeActives.Action;
    }
}
