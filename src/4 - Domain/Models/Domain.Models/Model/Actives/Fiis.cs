using Domain.Core.Model.Enumerables;
using System;

namespace Domain.Core.Model.Actives
{
    //classe de Fundos imobiliario brasil
    public sealed class Fiis : AbstractActives
    {

        public Fiis(Company company, string ticker) : base(company, ticker)
        {
        }

        public Fiis(Guid id, Company company, string ticker) : base(id, company, ticker)
        {
        }
        public override EnumCategory TypeActives => EnumCategory.FIIS;
    }
}
