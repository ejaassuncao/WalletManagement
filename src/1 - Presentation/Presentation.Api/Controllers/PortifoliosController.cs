using Domain.Core.Dto;
using Domain.Core.IServices;
using Domain.Core.Model.Enumerables;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortifoliosController : ControllerBase
    {
        private readonly IWalletService walletService;

        public PortifoliosController(IWalletService walletService)
        {
            this.walletService = walletService;
        }  
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortifolioDto>>> Get()
        {
            try
            {
                var result = await this.walletService.GetPortifolioAsync(EnumCategory.ALL);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task Post(PortifolioDto dto)
        {
            await this.walletService.Insert(dto);
        }
    }
}