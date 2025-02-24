using desafio.api.Requests;
using desafio.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafio.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraService _carteiraService;

        public CarteiraController(ICarteiraService carteiraService)
            => _carteiraService = carteiraService;

        [HttpPost]
        public async Task<IActionResult> CriarCarteira(CarteiraRequest request)
        {
            var result = await _carteiraService.ExecuteAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Created();
        }
    }
}
