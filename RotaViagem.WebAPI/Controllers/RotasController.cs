using Microsoft.AspNetCore.Mvc;
using RotaViagem.WebAPI.Models;
using RotaViagem.WebAPI.Services;

namespace RotaViagem.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RotasController : ControllerBase
    {
        private readonly ILogger<RotasController> _logger;

        public RotasController(ILogger<RotasController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Consultar")]
        public ResultResponse<RotaConsultarResponse> Consultar([FromQuery]RotaConsultarRequest request)
        {
            var service = new RotaService();
            return service.CalcRota(request);
        }

        [HttpPost(Name = "Nova")]
        public ResultResponse<RotaNovaRequest> Nova(RotaNovaRequest request)
        {
            var service = new RotaService();
            return service.InsertRota(request);
        }


    }
}