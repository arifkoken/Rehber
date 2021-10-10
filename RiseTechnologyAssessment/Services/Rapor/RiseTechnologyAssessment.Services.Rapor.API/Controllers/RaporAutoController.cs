using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaporAutoController : ControllerBase
    {
        [HttpPost]
        public void Talep([FromBody] RaporTalepDto model)
        {
        }

        [HttpGet]
        public IEnumerable<RaporListDto> Listele()
        {
            return new List<RaporListDto>() { };
        }


        [HttpGet("{id}")]
        public RaporDetayDto Detay(int id)
        {
            return new RaporDetayDto() { };
        }

    }
}
