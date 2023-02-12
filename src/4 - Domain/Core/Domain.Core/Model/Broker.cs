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
        public string RazãoSocial { get; init; }
        public string CNPJ { get; init; }

        public Broker(string nomeFantasia, string razãoSocial, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazãoSocial = razãoSocial;
            CNPJ = cnpj;
        }

        public Broker(Guid id, string nomeFantasia, string razãoSocial, string cnpj) : base(id)
        {
            NomeFantasia = nomeFantasia;
            RazãoSocial = razãoSocial;
            CNPJ = cnpj;
        }
    }
}
