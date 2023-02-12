using Domain.Commons.Entity;
using Domain.Core.Model.Actives;
using System;

namespace Domain.Core.Model
{
    /// <summary>
    /// Classe de gerencimento de proventos
    /// </summary>
    public class Earnings : EntityBase
    {
        public AbstractActives Active { get; init; }
        public string Type { get; init; } //dividendos/juros sobre capital, Bonificação desdobramento, Redimentos
        public DateTime Date { get; init; }


        public Earnings(AbstractActives active, string type, DateTime date)
        {
            Active = active;
            Type = type;
            Date = date;
        }

        public Earnings(Guid id, AbstractActives active, string type, DateTime date) : base(id)
        { 
            Active = active;
            Type = type;
            Date = date;
        }
    }
}
