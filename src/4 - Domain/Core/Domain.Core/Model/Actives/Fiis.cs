namespace Domain.Core.Model.Actives
{
    public sealed class Fiis : AbstractActives
    {     

        public Fiis(Company company, string ticker, int amount, double unitCost) : base(company, ticker, amount, unitCost)
        {
        }

        public Fiis(int id, Company company, string ticker, int amount, double unitCost) : base(id, company, ticker, amount, unitCost)
        {
        }

        public override TypeActives TypeActives => TypeActives.Fiis;
    }
}
