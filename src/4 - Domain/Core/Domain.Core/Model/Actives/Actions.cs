using Domain.Core.Model.Enumerables;
using System;

namespace Domain.Core.Model.Actives
{
    /// <summary>
    /// classe de ações brasil
    /// </summary>
    /// <seealso cref="Domain.Core.Model.Actives.AbstractActives" />
    public sealed class Actions : AbstractActives
    {
        public Actions(Company company, string ticker) : base(company, ticker)
        {
        }

        public Actions(int id, Company company, string ticker) : base(id, company, ticker)
        {
        }
        public override EnumTypeActives TypeActives => EnumTypeActives.Action;        
    }
}
