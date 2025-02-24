using desafio.api.Requests;
using desafio.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafio.api.Controllers
{
    [ApiController]
    [Route("transfer")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferenciaService;

        public TransferenciaController(ITransferenciaService transferenciaService)
            => _transferenciaService = transferenciaService;

        [HttpPost]
        public async Task<IActionResult> CriarTransferencia(TransferenciaRequest request)
        {

            var result = await _transferenciaService.ExecuteAsync(request);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
