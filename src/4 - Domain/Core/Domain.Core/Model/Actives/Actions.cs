namespace Domain.Core.Model.Actives
{
    public sealed class Actions : AbstractActives
    {
        public Actions(Company company, string ticker, int amount, double unitCost) : base(company, ticker, amount, unitCost)
        {
        }

        public Actions(int id, Company company, string ticker, int amount, double unitCost) : base(id, company, ticker, amount, unitCost)
        {
        }

        public override TypeActives TypeActives => TypeActives.Action;
    }
}
