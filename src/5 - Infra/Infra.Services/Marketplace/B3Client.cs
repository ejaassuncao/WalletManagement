using Domain.Core.Enumerables;
using Domain.Core.Interfaces;
using Domain.Core.Model.Actives;
using Domain.Core.Model.Enumerables;

namespace Infra.Services.Marketplace
{
    public class B3Client : IMarketplaceService
    {
        public string Url => "";

        public Task<dynamic> GetAsync(string ticker)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindAllTickers(string ticker)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetPriceAsync(string ticker)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(Url);

                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();
                    var abstractActives = AbstractActives.Parser(content);

                    return await Task.FromResult(abstractActives);
                }
                throw new HttpRequestException($"StatusCode: {result.StatusCode} - Message: {result.Content}");
            }
        }

        public Task<IEnumerable<string>> FindAllTickers(string ticker, EnumTypeActives enumTypeActives = EnumTypeActives.ALL, EnumExchanges exchange = EnumExchanges.ALL)
        {
            throw new NotImplementedException();
        }
    }
}