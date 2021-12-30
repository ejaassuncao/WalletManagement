using Domain.Core.Model.Actives;

namespace Service.Core
{
    public sealed class TotalPriceTypeActives
    {
        public TypeActives TypeActives { get; internal set; }
        public double TotalCost { get; internal set; }
        public double TotalCostPercent { get; internal set; }
    }
}
