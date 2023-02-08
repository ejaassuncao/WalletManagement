using Domain.Core.Model.Enumerables;

namespace Domain.Core.Model.Actives
{
    //classe de Fundos imobiliario brasil
    public sealed class Fiis : AbstractActives
    {

        public Fiis(Company company, string ticker) : base(company, ticker)
        {
        }

        public Fiis(int id, Company company, string ticker) : base(id, company, ticker)
        {
        }
        public override EnumTypeActives TypeActives => EnumTypeActives.FIIS;
    }
}
