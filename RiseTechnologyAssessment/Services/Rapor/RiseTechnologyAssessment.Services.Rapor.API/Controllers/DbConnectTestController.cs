using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RiseTechnologyAssessment.Services.Rapor.API.Db;

namespace RiseTechnologyAssessment.Services.Rapor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbConnectTestController : ControllerBase
    {

        private readonly RaporContext _context;
        public DbConnectTestController(RaporContext context)
        {

            _context = context;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
           // _context.Rapors.Add(new Db.Rapor(){KonumId=1,KonumAd="Ankara",TalepZamani=DateTime.Now});
           // _context.SaveChanges();
            return _context.Rapors.Select(x =>x.KonumAd).ToArray();
        }
    }
}
