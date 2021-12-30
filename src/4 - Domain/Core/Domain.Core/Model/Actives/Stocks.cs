namespace Domain.Core.Model.Actives
{
    /// <summary>
    /// Ativos
    /// </summary>
    public sealed class Stocks : AbstractActives
    {
        public Stocks(Company company, string ticker, int amount, double unitCost) 
            : base(company, ticker, amount, unitCost)
        {
        }

        public Stocks(int id, Company company, string ticker, int amount, double unitCost)
            : base(id, company, ticker, amount, unitCost)
        {
        }
        
        public override TypeActives TypeActives => TypeActives.Stockes;

    }
}