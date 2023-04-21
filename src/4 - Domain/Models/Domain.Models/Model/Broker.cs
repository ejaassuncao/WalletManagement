using Domain.Commons.Entity;
using System;

namespace Domain.Core.Model
{
    /// <summary>
    /// Corretora
    /// </summary>
    public sealed class Broker : EntityBase
    {
        public string FantasyName { get; init; }
        public string CorporateName { get; init; }
        public string CNPJ { get; init; }

        private Broker()
        {

        }

        public Broker(string fantasyName, string corporateName, string cnpj)
        {
            FantasyName = fantasyName;
            CorporateName = corporateName;
            CNPJ = cnpj;
        }

        public Broker(Guid id, string fantasyName, string corporateName, string cnpj) : base(id)
        {
            FantasyName = fantasyName;
            CorporateName = corporateName;
            CNPJ = cnpj;
        }
    }
}
