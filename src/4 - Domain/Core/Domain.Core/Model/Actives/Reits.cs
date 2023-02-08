using Domain.Core.Model.Enumerables;

namespace Domain.Core.Model.Actives
{
    //fundos imbiliarios internacionis
    public sealed class Reits : AbstractActives
    {
        public Reits(Company company, string ticker) : base(company, ticker)
        {
        }

        public Reits(int id, Company company, string ticker) : base(id, company, ticker)
        {
        }
        public override EnumTypeActives TypeActives => EnumTypeActives.REITS;
    }
}
