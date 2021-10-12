using Microsoft.AspNetCore.Mvc;
using RiseTechnologyAssessment.Services.Rehber.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rehber.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly IKisiService _kisiService;
        public KisiController(IKisiService kisiService)
        {
            _kisiService = kisiService;
        }
        [HttpPost]
        public IActionResult Ekle([FromBody] KisiOlusturDto model)
        {
            var result = _kisiService.KisiOlustur(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public IActionResult Sil(int id)
        {
            var result = _kisiService.KisiSil(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult IletisimBilgisiEkle([FromBody] KisiEkBilgiOlusturDto model)
        {
            var result = _kisiService.KisiBilgisiOlustur(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpDelete("{id}")]
        public IActionResult IletisimBilgisiSil(int id)
        {
            var result = _kisiService.KisiEkBilgiSil(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult Listele()
        {
            var result = _kisiService.Listele();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public IActionResult Detay(int id)
        {
            var result = _kisiService.Detay(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{raporid}/{konumId}")]
        public IActionResult KonumaGoreRehberVerileri(int raporId, int konumId)
        {
            var result = _kisiService.KonumaGoreRehberVerileri(raporId, konumId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
