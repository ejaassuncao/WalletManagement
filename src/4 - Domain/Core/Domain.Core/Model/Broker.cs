using Domain.Commons.Entity;
using System;

namespace Domain.Core.Model
{
    /// <summary>
    /// Corretora
    /// </summary>
    public sealed class Broker : EntityBase
    {
        public string NomeFantasia { get; init; }
        public string RazaoSocial { get; init; }
        public string CNPJ { get; init; }

        private Broker()
        {

        }

        public Broker(string nomeFantasia, string razãoSocial, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razãoSocial;
            CNPJ = cnpj;
        }

        public Broker(Guid id, string nomeFantasia, string razãoSocial, string cnpj) : base(id)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razãoSocial;
            CNPJ = cnpj;
        }
    }
}
