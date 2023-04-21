using Domain.Core.Model.Enumerables;
using System;

namespace Domain.Core.Model.Actives
{
    //fundos imbiliarios internacionis
    public sealed class Reits : AbstractActives
    {
        public Reits(Company company, string ticker) : base(company, ticker)
        {
        }

        public Reits(Guid id, Company company, string ticker) : base(id, company, ticker)
        {
        }
        public override EnumCategory TypeActives => EnumCategory.REITS;
    }
}
