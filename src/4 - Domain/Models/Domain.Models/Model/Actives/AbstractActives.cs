﻿using Domain.Commons.Entity;
using Domain.Commons.Validate;
using Domain.Core.Model.Enumerables;
using System;
using System.Threading.Tasks;

namespace Domain.Core.Model.Actives
{
    public abstract class AbstractActives : EntityBase
    {

        #region properties
        public Company Company { get; protected set; }

        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; protected set; }
   

        /// <summary>
        /// Cotação
        /// </summary>
        public decimal Price { get; protected set; }

        /// <summary>
        /// Tipo de ativos
        /// </summary>       
        public abstract EnumCategory Category { get; }

        #endregion

        public AbstractActives()
        {

        }

        public AbstractActives(Guid id, Company company, string ticker) : base(id)
        {
            ValidateDomain(company, ticker);
        }

        public AbstractActives(Company company, string ticker)
        {
            ValidateDomain(company, ticker);
        }

        /// <summary>
        /// Validações do modelo
        /// </summary>        
        private void ValidateDomain(Company company, string tiker)
        {
            //ExceptionDomainValidation.When(company == null, "Company is null");
           // ExceptionDomainValidation.When(!company.ExistsTicker(tiker), "Ticker not found");
            Company = company;
            Ticker = tiker;
        }

        public void UpdatePrice(decimal price)
        {
            this.Price = price;
        }

        public static AbstractActives Parser(Task<string> content)
        {
            throw new NotImplementedException();
        }

        public static AbstractActives Parser(string content)
        {
            throw new NotImplementedException();
        }
    }
}
