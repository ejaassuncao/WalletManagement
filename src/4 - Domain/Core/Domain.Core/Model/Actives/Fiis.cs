using System;

namespace Domain.Core.Model.Actives
{
    public sealed class Fiis : AbstractActives
    {     

        public Fiis(Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(company, ticker, amount, unitCost, dateBuy)
        {
        }

        public Fiis(int id, Company company, string ticker, int amount, double unitCost, DateTime dateBuy) : base(id, company, ticker, amount, unitCost, dateBuy)
        {
        }

        public override TypeActives TypeActives => TypeActives.Fiis;
    }
}
