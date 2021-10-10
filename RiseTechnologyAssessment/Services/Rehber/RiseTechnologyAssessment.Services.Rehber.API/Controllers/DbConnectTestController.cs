using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rehber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbConnectTestController : ControllerBase
    {
        private readonly RehberContext _context;
        public DbConnectTestController(RehberContext context)
        {

            _context = context;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
            // _context.Konums.Add(new Konum(){Ad="Ankara"});
            // _context.SaveChanges();
            return _context.Konums.Select(x => x.Ad).ToArray();
        }

    }
}
