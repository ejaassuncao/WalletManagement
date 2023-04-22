using Domain.Core.Model.Enumerables;

namespace Service.Core.Dtos
{
    public class TotalPriceTypeActivesDto
    {
        public EnumCategory TypeActives { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostPercent { get; set; }
    }
}
