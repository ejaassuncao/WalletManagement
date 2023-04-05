using Domain.Core.Model.Enumerables;
using System;

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

        public Stocks(Guid id, Company company, string ticker) : base(id, company, ticker)
        {
        }

        public override EnumTypeActives TypeActives => EnumTypeActives.STOCKES;
    }
}