using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using RiseTechnologyAssessment.Services.Rehber.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rehber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbConnectTestController : ControllerBase
    {
        private readonly IKisiService _kisiService;
        public DbConnectTestController(IKisiService kisiService)
        {
            _kisiService = kisiService;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
            // _context.Konums.Add(new Konum(){Ad="Ankara"});
            // _context.SaveChanges();
            return _kisiService.KonumListele();
        }

    }
}
