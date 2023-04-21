namespace Domain.Core.Dto
{
    public record PortifolioDto(
         string Category,
         string Sector,
         string Ticker,
         decimal Price,
         decimal Amount,
         decimal Cost,
         decimal TotalPrice,
         decimal TotalCost,
         string LP
    );
}
