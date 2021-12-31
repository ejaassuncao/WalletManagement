using Domain.core.IRepository;
using Domain.Core.Model;

namespace Application.Core.Wallat
{
    public class WalletCommandInsertApplication : IExecuting<WalletCommandInsertDTO>
    {       
        private readonly IWalletRespository _WallatRepository;

        public WalletCommandInsertApplication(IWalletRespository wallatRepository)
        {            
            _WallatRepository = wallatRepository;
        }

        public WalletCommandInsertDTO Execute(WalletCommandInsertDTO obj)
        {          
            Wallet wallet = Mappper<Wallet>.Parse(obj);     
            
            wallet = _WallatRepository.Insert(wallet);

            return Mappper<WalletCommandInsertDTO>.Parse(wallet);
        }
    }
}
