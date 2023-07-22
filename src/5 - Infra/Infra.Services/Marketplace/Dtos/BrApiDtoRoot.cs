using System.Text.Json.Serialization;

namespace Infra.Services.Marketplace.Dtos
{
    public class BrApiDtoRoot
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("requestedAt")]
        public DateTime? RequestedAt { get; set; }
    }
  
    public class CashDividend
    {
        [JsonPropertyName("assetIssued")]
        public string AssetIssued { get; set; }

        [JsonPropertyName("paymentDate")]
        public DateTime? PaymentDate { get; set; }

        [JsonPropertyName("rate")]
        public double? Rate { get; set; }

        [JsonPropertyName("relatedTo")]
        public string RelatedTo { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("isinCode")]
        public string IsinCode { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("lastDatePrior")]
        public DateTime? LastDatePrior { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }
    }

    public class DividendsData
    {
        [JsonPropertyName("cashDividends")]
        public List<CashDividend> CashDividends { get; set; }

        [JsonPropertyName("stockDividends")]
        public List<StockDividend> StockDividends { get; set; }

        [JsonPropertyName("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }

    public class HistoricalDataPrice
    {
        [JsonPropertyName("date")]
        public int? Date { get; set; }

        [JsonPropertyName("open")]
        public double? Open { get; set; }

        [JsonPropertyName("high")]
        public double? High { get; set; }

        [JsonPropertyName("low")]
        public double? Low { get; set; }

        [JsonPropertyName("close")]
        public double? Close { get; set; }

        [JsonPropertyName("volume")]
        public int? Volume { get; set; }

        [JsonPropertyName("adjustedClose")]
        public double? AdjustedClose { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("longName")]
        public string LongName { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public double? RegularMarketPrice { get; set; }

        [JsonPropertyName("regularMarketDayHigh")]
        public double? RegularMarketDayHigh { get; set; }

        [JsonPropertyName("regularMarketDayLow")]
        public double? RegularMarketDayLow { get; set; }

        [JsonPropertyName("regularMarketDayRange")]
        public string RegularMarketDayRange { get; set; }

        [JsonPropertyName("regularMarketChange")]
        public double? RegularMarketChange { get; set; }

        [JsonPropertyName("regularMarketChangePercent")]
        public double? RegularMarketChangePercent { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public DateTime? RegularMarketTime { get; set; }

        [JsonPropertyName("marketCap")]
        public long? MarketCap { get; set; }

        [JsonPropertyName("regularMarketVolume")]
        public int? RegularMarketVolume { get; set; }

        [JsonPropertyName("regularMarketPreviousClose")]
        public double? RegularMarketPreviousClose { get; set; }

        [JsonPropertyName("regularMarketOpen")]
        public double? RegularMarketOpen { get; set; }

        [JsonPropertyName("averageDailyVolume10Day")]
        public int? AverageDailyVolume10Day { get; set; }

        [JsonPropertyName("averageDailyVolume3Month")]
        public int? AverageDailyVolume3Month { get; set; }

        [JsonPropertyName("fiftyTwoWeekLowChange")]
        public double? FiftyTwoWeekLowChange { get; set; }

        [JsonPropertyName("fiftyTwoWeekLowChangePercent")]
        public double? FiftyTwoWeekLowChangePercent { get; set; }

        [JsonPropertyName("fiftyTwoWeekRange")]
        public string FiftyTwoWeekRange { get; set; }

        [JsonPropertyName("fiftyTwoWeekHighChange")]
        public double? FiftyTwoWeekHighChange { get; set; }

        [JsonPropertyName("fiftyTwoWeekHighChangePercent")]
        public double? FiftyTwoWeekHighChangePercent { get; set; }

        [JsonPropertyName("fiftyTwoWeekLow")]
        public double? FiftyTwoWeekLow { get; set; }

        [JsonPropertyName("fiftyTwoWeekHigh")]
        public double? FiftyTwoWeekHigh { get; set; }

        [JsonPropertyName("twoHundredDayAverage")]
        public double? TwoHundredDayAverage { get; set; }

        [JsonPropertyName("twoHundredDayAverageChange")]
        public double? TwoHundredDayAverageChange { get; set; }

        [JsonPropertyName("twoHundredDayAverageChangePercent")]
        public double? TwoHundredDayAverageChangePercent { get; set; }

        [JsonPropertyName("validRanges")]
        public List<string> ValidRanges { get; set; }

        [JsonPropertyName("historicalDataPrice")]
        public List<HistoricalDataPrice> HistoricalDataPrice { get; set; }

        [JsonPropertyName("priceEarnings")]
        public double? PriceEarnings { get; set; }

        [JsonPropertyName("earningsPerShare")]
        public double? EarningsPerShare { get; set; }

        [JsonPropertyName("logourl")]
        public string Logourl { get; set; }

        [JsonPropertyName("dividendsData")]
        public DividendsData DividendsData { get; set; }
    }

    public class StockDividend
    {
        [JsonPropertyName("assetIssued")]
        public string AssetIssued { get; set; }

        [JsonPropertyName("factor")]
        public double? Factor { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("isinCode")]
        public string IsinCode { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("lastDatePrior")]
        public DateTime? LastDatePrior { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("assetIssued")]
        public string AssetIssued { get; set; }

        [JsonPropertyName("percentage")]
        public double? Percentage { get; set; }

        [JsonPropertyName("priceUnit")]
        public double? PriceUnit { get; set; }

        [JsonPropertyName("tradingPeriod")]
        public string TradingPeriod { get; set; }

        [JsonPropertyName("subscriptionDate")]
        public DateTime? SubscriptionDate { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("isinCode")]
        public string IsinCode { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("lastDatePrior")]
        public DateTime? LastDatePrior { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }
    }




}
