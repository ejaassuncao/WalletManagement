using Domain.Core.Model.Enumerables;
using System;

namespace Domain.Models.Dto
{
    public class ActiveDto
    {
        public EnumOperationWallet Operation { get; set; } = EnumOperationWallet.BUY;

        public string NameCompany { get; set; }
        public string NameSector{ get; set; }

        public string Ticker { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Amount { get; set; }
        public decimal UnitCost { get; set; }
    }
}
