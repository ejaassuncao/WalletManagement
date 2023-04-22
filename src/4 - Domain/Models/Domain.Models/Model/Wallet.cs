using Domain.Commons.Entity;
using Domain.Commons.Validate;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;
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
        #region MSG Validate        
        public static string MSG_SALES_LARGER_BUY = "The number of shares being sold is greater than the value of the portfolio";
        public static string MSG_NOT_EXIST_ACTIVE = "Active not found";
        public static string MSG_OWNER_NOT_FOUND = "Owner not found";
        public static string MSG_NAME_IS_NULL_OR_EMPTY = "Name is null or empty";
        public static string MSG_NAME_IS_MIN_LENGTH_3 = "Name is min length 3";
        public static string MSG_NAME_IS_MAX_LENGTH_255 = "Name is max length 255";
        #endregion

        #region properties

        public string Name { get; init; }

        public User Owner { get; init; }

        public Broker Broker { get; init; }

        private List<ActivesOfCompany> _actives;

        #endregion

        #region Metod
        public Wallet(Guid id, User owner, string name) : base(id)
        {
            ValidateDomain(owner, name);
            Owner = owner;
            Name = name;
            _actives = new List<ActivesOfCompany>();
        }

        public Wallet(User owner, string name)
        {
            ValidateDomain(owner, name);
            Owner = owner;
            Name = name;
            _actives = new List<ActivesOfCompany>();
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da cateria
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public decimal TotalCost(AbstractActives actives)
        {
            return _actives.Where(x => x.Active.Ticker == actives.Ticker).Sum(x => x.TotalCost);
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da carteria
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public decimal TotalCost()
        {
            return _actives.Sum(x => x.TotalCost);
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da cateria por ativo
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public decimal TotalCost(EnumCategory typeActives)
        {
            return _actives.Where(a => a.Active.Category == typeActives).Sum(x => x.TotalCost);
        }

        /// <summary>
        /// Totals the cost.
        /// Quantidade de ativos pro ticker
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public decimal TotalAmount(AbstractActives actives)
        {
            return _actives.Where(a => a.Active.Ticker == actives.Ticker).Sum(x => x.Amount);
        }

        /// <summary>
        /// Totals the cost.
        /// Quantidade de ativos na carteira
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public decimal TotalAmount()
        {
            return _actives.Sum(x => x.Amount);
        }

        /// <summary>
        /// Buys the specified active.
        /// adicionar uma compra na carteria de um determinado ativo
        /// </summary>
        /// <param name="active">The active.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="unitCost">The unit cost.</param>
        /// <param name="dateBuy">The date buy.</param>
        /// <param name="user">The user.</param>
        public void Buy(AbstractActives active, int amount, decimal unitCost, DateTime dateBuy, User user, Broker broker)
        {
            _actives.Add(new ActivesOfCompany(
                active: active,
                amount: amount,
                unitCost: unitCost,
                dateOperation: dateBuy,
                user: user,
                broker: broker,
                operation: EnumOperationWallet.BUY
            ));
        }

        /// <summary>
        /// Exists the active.
        /// Se existe o attivo na carteria
        /// </summary>
        /// <param name="active">The active.</param>
        /// <returns></returns>
        public bool ExistsActive(AbstractActives active)
        {
            return _actives.Any(x => x.Active.Ticker == active.Ticker);
        }

        /// <summary>
        /// Sales the specified active.
        /// Adicionar uma venda na carteria de um determinado ativo
        /// </summary>
        /// <param name="active">The active.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="unitSales">The unit sales.</param>
        /// <param name="dateBuy">The date buy.</param>
        /// <param name="user">The user.</param>
        public void Sale(AbstractActives active, int amount, decimal unitSales, DateTime dateBuy, User user)
        {
            ExceptionDomainValidation.When(!this.ExistsActive(active), MSG_NOT_EXIST_ACTIVE);
            ExceptionDomainValidation.When(this.TotalAmount(active) < amount, MSG_SALES_LARGER_BUY);

            _actives.Add(new ActivesOfCompany(
                active: active,
                amount: amount,
                unitCost: unitSales,
                dateOperation: dateBuy,
                user: user,
                operation: EnumOperationWallet.SALES
            ));
        }

        private void ValidateDomain(User owner, string name)
        {
            ExceptionDomainValidation.When(owner is null, MSG_OWNER_NOT_FOUND);

            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), MSG_NAME_IS_NULL_OR_EMPTY);

            ExceptionDomainValidation.When(name.Length < 3, MSG_NAME_IS_MIN_LENGTH_3);

            ExceptionDomainValidation.When(name.Length > 255, MSG_NAME_IS_MAX_LENGTH_255);
        }

        /// <summary>
        /// Retorna o valor do patrimonio da carteira
        /// pega todo as ações e soma a cotação atual
        /// </summary>
        /// <returns></returns>
        public decimal GetPatrimony()
        {           
            return _actives.Sum(x => (x.Active.Price * x.Amount));
        }

        /// <summary>
        /// Retorna Lucro/Prejetujo patrimonio
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public decimal GetProfit()
        {
            var patrimony = this.GetPatrimony();
            var totalCost = this.TotalCost();

            return patrimony - totalCost;
        }

        #endregion
    }
}
