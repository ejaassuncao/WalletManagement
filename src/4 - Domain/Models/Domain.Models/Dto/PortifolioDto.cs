using System;

namespace Domain.Core.Dto
{
    public class PortifolioDto
    {       
        public string Category { get; set; }
        public string Sector { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }        
        public decimal Amount { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal LP { get; set; }       
    }
}
