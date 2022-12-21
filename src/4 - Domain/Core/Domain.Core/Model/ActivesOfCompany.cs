using Domain.Commons.Entity;
using Domain.Commons.Validate;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
using System;

namespace Domain.Core.Model
{
    public class ActivesOfCompany
    {
        public AbstractActives Active { get; protected set; }

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
        /// Data da compra
        /// </summary>
        public DateTime DateBuy { get; protected set; }

        /// <summary>
        /// Data da compra
        /// </summary>
        public User User { get; protected set; }
        public EnumOperationWallet Operation { get; protected set; }

        public ActivesOfCompany(AbstractActives active, int amount, double unitCost, DateTime dateBuy, User user, EnumOperationWallet operation)
        {
            ExceptionDomainValidation.When(active is null, "active not found");
            ExceptionDomainValidation.When(amount <= 0, "amount is min or egual 0");
            ExceptionDomainValidation.When(unitCost <= 0, "unitCost is min or egual 0");
            ExceptionDomainValidation.When(dateBuy == default, "invalid date");
            ExceptionDomainValidation.When(user is null, "usert not found");

            amount = (operation == EnumOperationWallet.SALES) ? (amount * -1) : amount;

            Active = active;
            Amount = amount;
            UnitCost = unitCost;
            TotalCost = (amount * unitCost);
            //Caso for valor de venda negativa TotalCost
            DateBuy = dateBuy;
            User = user;
            Operation = operation;

        }
    }
}
