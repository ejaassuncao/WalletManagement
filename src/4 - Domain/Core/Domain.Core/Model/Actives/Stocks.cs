using Domain.Core.Model.Enumerables;

namespace Domain.Core.Model.Actives
{
    /// <summary>
    /// Ação internacionais
    /// </summary>
    public sealed class Stocks : AbstractActives
    {
        public Stocks(Company company, string ticker) : base(company, ticker)
        {
        }

        public Stocks(int id, Company company, string ticker) : base(id, company, ticker)
        {
        }

        public override EnumTypeActives TypeActives => EnumTypeActives.Stockes;
    }
}