using Domain.Core.Dto;
using Domain.Core.IServices;
using Domain.Core.Model.Enumerables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Presentation.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class PortifoliosController : ControllerBase
    {
        private readonly IWalletService walletService;

        public PortifoliosController(IWalletService walletService)
        {          
            this.walletService = walletService;
        }

        [HttpGet()]
        public async Task<IEnumerable<PortifolioDto>> Get()
        {
            return await this.walletService.GetPortifolioAsync(EnumTypeActives.ALL);
        }
    }
}