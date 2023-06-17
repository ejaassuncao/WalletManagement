using System;

namespace Domain.Models.Dto
{
    public class ActiveDto
    {
        public string Ticker { get; set; }
        public DateTime DateBuy { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public decimal UnitCost { get; set; }
    }
}
