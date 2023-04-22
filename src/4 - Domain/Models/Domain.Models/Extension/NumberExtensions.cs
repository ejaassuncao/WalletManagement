namespace Domain.Models.Extension
{
    public static class NumberExtensions
    {
        public static string ToCurrency(this decimal value)
        {
            return $"{value:C}";
        }

        public static string ToQuantity(this decimal value)
        {
            return value.ToString("0.000");
        }
    }
}
