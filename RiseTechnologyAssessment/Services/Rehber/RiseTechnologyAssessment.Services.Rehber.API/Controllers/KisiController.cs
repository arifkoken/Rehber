using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rehber.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KisiController : ControllerBase
    {

        [HttpPost]
        public void Ekle([FromBody] KisiOlusturDto model)
        {
        }

        [HttpDelete("{id}")]
        public void Sil(int id)
        {

        }

        [HttpPost]
        public void IletisimBilgisiEkle([FromBody] KisiEkBilgiOlusturDto model)
        {
        }

        [HttpDelete("{id}")]
        public void IletisimBilgisiSil(int id)
        {

        }


        [HttpGet]
        public IEnumerable<KisiListDto> Listele()
        {
            return new List<KisiListDto>() { };
        }


        [HttpGet("{id}")]
        public KisiDetayDto Detay(int id)
        {
            return new KisiDetayDto() { };
        }

    }
}
