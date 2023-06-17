using Domain.Models.Dto;
using System.Text.Json.Serialization;

namespace Infra.Services.Marketplace.Dtos
{
    public class TradingViewRoot
    {
        [JsonPropertyName("symbols_remaining")]
        public int SymbolsRemaining { get; set; }

        [JsonPropertyName("symbols")]
        public List<TradingViewSymbol>? Symbols { get; set; }

        public IEnumerable<string> ToList()
        {
            var list = new List<string>();

            if (Symbols is null) return list;           
            
            foreach (var symbol in Symbols)            
                list.Add($"{symbol.Symbol?.Replace("<em>", "").Replace("</em>", "")} - {symbol.Description}");                
        
            return list;
        }

        public IEnumerable<ItemList> ToItemList()
        {
            var list = new List<ItemList>();

            if (Symbols is null) return list;

            foreach (var symbol in Symbols)
                list.Add(new ItemList(null, symbol.Symbol?.Replace("<em>", "").Replace("</em>", ""), symbol.Description?.Replace("<em>", "").Replace("</em>", "")));                  

            return list;
        }        
    }
}
