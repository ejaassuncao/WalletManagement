using Domain.Core.Model.Enumerables;

namespace Service.Core.Dtos
{
    public class TotalPriceTypeActivesDto
    {
        public EnumCategory TypeActives { get; set; }
        public double TotalCost { get; set; }
        public double TotalCostPercent { get; set; }
    }
}
