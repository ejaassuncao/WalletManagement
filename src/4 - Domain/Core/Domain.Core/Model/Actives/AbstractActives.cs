﻿using Domain.Commons.Entity;
using Domain.Commons.Validate;
using Domain.Core.Model.Enumerables;

namespace Domain.Core.Model.Actives
{
    public abstract class AbstractActives : EntityBase
    {
        public AbstractActives(int id, Company company, string ticker) : base(id)
        {
            ValidateDomain(company, ticker);
        }

        public AbstractActives(Company company, string ticker)
        {
            ValidateDomain(company, ticker);
        }

        public Company Company { get; protected set; }

        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; protected set; }

        /// <summary>
        /// Cotação
        /// </summary>
        public double Counting { get; protected set; }

        /// <summary>
        /// Tipo de ativos
        /// </summary>       
        public abstract EnumTypeActives TypeActives { get; }

        /// <summary>
        /// Validações do modelo
        /// </summary>        
        private void ValidateDomain(Company company, string tiker)
        {
            ExceptionDomainValidation.When(company == null, "Company is null");
            ExceptionDomainValidation.When(!company.ExistsTicker(tiker), "Ticker not found");
            Company = company;
            Ticker = tiker;
        }
    }  
}
