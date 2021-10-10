using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;

namespace RiseTechnologyAssessment.Services.Rapor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbConnectTestController : ControllerBase
    {

        private readonly IRaporService _raporService;
        public DbConnectTestController(IRaporService raporService)
        {
            _raporService = raporService;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
           // _context.Rapors.Add(new Db.Rapor(){KonumId=1,KonumAd="Ankara",TalepZamani=DateTime.Now});
           // _context.SaveChanges();
           return _raporService.RaporListele();
        }
    }
}
