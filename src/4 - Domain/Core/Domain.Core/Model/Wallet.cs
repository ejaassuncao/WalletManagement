using Domain.Core.Model.Actives;
using Domain.Core.Validate;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Model
{
    /// <summary>
    /// carteira
    /// </summary>
    public sealed class Wallet : EntityBase
    {
        public string Name { get; private set; }

        public List<AbstractActives> Actives { get; private set; }

        public Wallet(int id, string name)
        {
            ExceptionDomainValidation.When(id <= 0, "Id is min or egual 0");
            Id = id;

            ValidateDomain(name);
        }

        public Wallet(string name)
        {
            ValidateDomain(name);
        }

        public double TotalCost()
        {
            return Actives.Sum(x => x.TotalCost);

        }
        public double TotalCost(TypeActives typeActives)
        {
            return Actives.Where(a=>a.TypeActives== typeActives).Sum(x => x.TotalCost);
        }

        private void ValidateDomain(string name)
        {
            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), "Name is null or empty");

            ExceptionDomainValidation.When(name.Length < 3, "Name is min length 3");

            ExceptionDomainValidation.When(name.Length > 255, "Name is max length 255");

            Name = name;
            Actives = new List<AbstractActives>();

        }      
    }
       
}
