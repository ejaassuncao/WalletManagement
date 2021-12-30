namespace Domain.Core.Model.Actives
{
    public sealed class Reits : AbstractActives
    {
        public Reits(Company company, string ticker, int amount, double unitCost) : base(company, ticker, amount, unitCost)
        {
        }

        public Reits(int id, Company company, string ticker, int amount, double unitCost) : base(id, company, ticker, amount, unitCost)
        {
        }

        public override TypeActives TypeActives => TypeActives.Reits;
    }
}
