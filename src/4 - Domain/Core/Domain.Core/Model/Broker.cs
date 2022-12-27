using Domain.Commons.Entity;

namespace Domain.Core.Model
{
    /// <summary>
    /// Corretora
    /// </summary>
    public sealed class Broker : EntityBase
    {
        public string NomeFantasia { get; set; }
        public string RazãoSocial { get; set; }
        public string CNPJ { get; set; }

        public Broker(string nomeFantasia, string razãoSocial, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazãoSocial = razãoSocial;
            CNPJ = cnpj;
        }

        public Broker(int id, string nomeFantasia, string razãoSocial, string cnpj) : base(id)
        {
            NomeFantasia = nomeFantasia;
            RazãoSocial = razãoSocial;
            CNPJ = cnpj;
        }
    }
}
