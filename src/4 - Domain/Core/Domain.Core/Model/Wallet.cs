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
        //todo: colocar todas  como contantes aplicar em outras classes
        public static string MSG_SALES_LARGER_BUY = "The number of shares being sold is greater than the value of the portfolio";
        public static string MSG_NOT_EXIST_ACTIVE = "The number of shares being sold is greater than the value of the portfolio";       

        #endregion

        public User Owner { get; set; }

        public string Name { get; private set; }

        private List<ActivesOfCompany> _actives;
      

        public Wallet(int id, User owner, string name) : base(id)
        {
            ValidateDomain(owner, name);
        }

        public Wallet(User owner, string name)
        {
            ValidateDomain(owner, name);
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da cateria
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public double TotalCost(AbstractActives actives)
        {
            return _actives.Where(x=>x.Active.Ticker== actives.Ticker).Sum(x => x.TotalCost);
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da cateria
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public double TotalCost()
        {
            return _actives.Sum(x => x.TotalCost);
        }

        /// <summary>
        /// Totals the cost.
        /// soma do custo total da cateria por ativo
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public double TotalCost(EnumTypeActives typeActives)
        {
            return _actives.Where(a => a.Active.TypeActives == typeActives).Sum(x => x.TotalCost);
        }


        /// <summary>
        /// Totals the cost.
        /// Quantidade de ativos pro ticker
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public int TotalAmount(AbstractActives actives)
        {          
            return _actives.Where(a => a.Active.Ticker == actives.Ticker).Sum(x => x.Amount);
        }

        /// <summary>
        /// Totals the cost.
        /// Quantidade de ativos na carteira
        /// </summary>
        /// <param name="typeActives">The type actives.</param>
        /// <returns></returns>
        public int TotalAmount()
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
        public void Buy(AbstractActives active, int amount, double unitCost, DateTime dateBuy, User user)
        {
            _actives.Add(new ActivesOfCompany(
                active: active,
                amount: amount,
                unitCost: unitCost,
                dateBuy: dateBuy,
                user: user,
                operation: EnumOperationWallet.BUY
            ));
        }

        /// <summary>
        /// Exists the active.
        /// Se existe o attivo na carteria
        /// </summary>
        /// <param name="active">The active.</param>
        /// <returns></returns>
        public bool ExistActive(AbstractActives active)
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
        public void Sale(AbstractActives active, int amount, double unitSales, DateTime dateBuy, User user)
        {
            ExceptionDomainValidation.When(!this.ExistActive(active), MSG_NOT_EXIST_ACTIVE);                        
            ExceptionDomainValidation.When(this.TotalAmount(active) < amount, MSG_SALES_LARGER_BUY);

            _actives.Add(new ActivesOfCompany(
                active: active,
                amount: amount,
                unitCost: unitSales,
                dateBuy: dateBuy,
                user: user,
                operation: EnumOperationWallet.SALES
            ));
        }       

        private void ValidateDomain(User owner, string name)
        {
            ExceptionDomainValidation.When(owner is null, "owner not found");

            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), "Name is null or empty");

            ExceptionDomainValidation.When(name.Length < 3, "Name is min length 3");

            ExceptionDomainValidation.When(name.Length > 255, "Name is max length 255");

            Owner = owner;
            Name = name;
            _actives = new List<ActivesOfCompany>();
        }
    }
}
