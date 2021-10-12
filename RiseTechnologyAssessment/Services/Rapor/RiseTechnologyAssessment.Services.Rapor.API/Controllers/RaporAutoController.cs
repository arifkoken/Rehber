using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaporAutoController : ControllerBase
    {
        private readonly IRaporService _raporService;
       private readonly IBus _bus;
        public RaporAutoController(IRaporService raporService, IBus bus)
        {
            _raporService = raporService;
            _bus = bus;
        }
        [HttpPost]
        public IActionResult Talep([FromBody] RaporTalepDto model)
        {
            var result = _raporService.TalepOlustur(model);

            //Todo Her Endpoint içinde if'le response belirlememek için alt katmandan gelen resulta göre dönüş türünü belirleyen bir method yazılacak( Base Controller içerisine)
            if (result.Success)
            {
                _bus.Publish(result.Data);
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult Listele()
        {
            var result = _raporService.Listele();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("{id}")]
        public IActionResult Detay(int id)
        {
            var result = _raporService.Detay(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
