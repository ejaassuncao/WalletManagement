using Domain.Core.Model.Actives;
using Domain.Core.Validate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Model
{
    /// <summary>
    /// carteira
    /// </summary>
    public sealed class Wallet : EntityBase
    {
        public int Owner { get; set; }

        public string Name { get; private set; }

        private List<AbstractActives> _actives;

        public Wallet(int id, int owner, string name):base(id)
        {
            ValidateDomain(owner, name);           
        }

        public Wallet(int owner, string name)
        {
            ValidateDomain(owner, name);
        }

        public double TotalCost()
        {
            return _actives.Sum(x => x.TotalCost);

        }
        public double TotalCost(TypeActives typeActives)
        {
            return _actives.Where(a=>a.TypeActives== typeActives).Sum(x => x.TotalCost);
        }

        public void Buy(AbstractActives actions)
        {
            _actives.Add(actions);
        }

        public void Buy(IEnumerable<AbstractActives> actions)
        {
            _actives.AddRange(actions);
        }


        private void ValidateDomain(int owner, string name)
        {
            ExceptionDomainValidation.When(owner<=0, "owner not found");

            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), "Name is null or empty");

            ExceptionDomainValidation.When(name.Length < 3, "Name is min length 3");

            ExceptionDomainValidation.When(name.Length > 255, "Name is max length 255");

            Owner = owner;
            Name = name;
            _actives = new List<AbstractActives>();

        }      
    }
       
}
