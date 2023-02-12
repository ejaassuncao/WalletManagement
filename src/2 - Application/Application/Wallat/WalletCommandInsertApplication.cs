using Domain.core.IRepository;
using Domain.Core.Model;
using System.Threading.Tasks;

namespace Application.Core.Wallat
{
    public class WalletCommandInsertApplication : IExecuting<WalletCommandInsertDTO>
    {       
        private readonly IWalletRespository _WallatRepository;

        public WalletCommandInsertApplication(IWalletRespository wallatRepository)
        {            
            _WallatRepository = wallatRepository;
        }

        public async Task<WalletCommandInsertDTO> ExecuteAsync(WalletCommandInsertDTO obj)
        {          
            Wallet wallet = Mappper<Wallet>.Parse(obj);     
            
            wallet = await _WallatRepository.InsertAsync(wallet);

            return Mappper<WalletCommandInsertDTO>.Parse(wallet);
        }

       
    }
}
