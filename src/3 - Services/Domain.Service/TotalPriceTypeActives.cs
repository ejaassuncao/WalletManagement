using Domain.Core.Model.Enumerables;

namespace Service.Core
{
    public sealed class TotalPriceTypeActives
    {
        public EnumTypeActives TypeActives { get; internal set; }
        public double TotalCost { get; internal set; }
        public double TotalCostPercent { get; internal set; }
    }
}
