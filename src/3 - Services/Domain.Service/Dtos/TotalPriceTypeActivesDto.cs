using Domain.Core.Model.Enumerables;

namespace Service.Core.Dtos
{
    public sealed class TotalPriceTypeActivesDto
    {
        public EnumTypeActives TypeActives { get; internal set; }
        public double TotalCost { get; internal set; }
        public double TotalCostPercent { get; internal set; }
    }
}
