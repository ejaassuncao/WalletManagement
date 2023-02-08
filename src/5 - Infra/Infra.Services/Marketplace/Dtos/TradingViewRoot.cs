using System.Text.Json.Serialization;

namespace Infra.Services.Marketplace.Dtos
{
    public class TradingViewRoot
    {
        [JsonPropertyName("symbols_remaining")]
        public int SymbolsRemaining { get; set; }

        [JsonPropertyName("symbols")]
        public List<TradingViewSymbol> Symbols { get; set; }

        public IEnumerable<string> ToList()
        {
            var list = new List<string>();
            foreach (var item in Symbols)
            {
                list.Add($"{item._Symbol.Replace("<em>", "").Replace("</em>", "")} - {item.Description}");
                
            }
            return list;
        }
    }
}
