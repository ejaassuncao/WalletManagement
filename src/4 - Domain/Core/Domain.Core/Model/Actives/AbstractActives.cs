using Domain.Core.Validate;

namespace Domain.Core.Model.Actives
{
    public abstract class AbstractActives: EntityBase
    {
        public AbstractActives(int id, Company company, string ticker, int amount, double unitCost)
        {
            ExceptionDomainValidation.When(id <= 0, "Id is min or egual 0");
            Id = id;
            ValidateDomain(company, ticker, amount, unitCost);
        }

        public AbstractActives(Company company, string ticker, int amount, double unitCost)
        {
            ValidateDomain(company, ticker, amount, unitCost);
        }

        public Company Company { get; protected set; }

        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; protected set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Amount { get; protected set; }

        /// <summary>
        /// Custo unitário
        /// </summary>
        public double UnitCost { get; protected set; }

        /// <summary>
        /// Custo total
        /// </summary>
        public double TotalCost { get; protected set; }

        /// <summary>
        /// Cotação
        /// </summary>
        public double Counting { get; protected set; }

        /// <summary>
        /// Tipo de ativos
        /// </summary>       
        public abstract TypeActives TypeActives { get; }

        /// <summary>
        /// Validaões do modelo
        /// </summary>        
        private void ValidateDomain(Company company, string tiker, int amount, double unitCost)
        {
            ExceptionDomainValidation.When(company == null, "Company is null");
            ExceptionDomainValidation.When(!company.ExistsTicker(tiker), "Ticker not found");
            ExceptionDomainValidation.When(amount <= 0, "Amount not min or equal 0");
            ExceptionDomainValidation.When(unitCost <= 0, "Cost not min or equal  0");

            Company = company;
            Ticker = tiker;
            Amount = amount;
            UnitCost = unitCost;
            TotalCost += amount*UnitCost;
        }
            
    }

    public enum TypeActives 
    {     
        Action,
        Stockes,
        Fiis,
        Reits
    }

}
