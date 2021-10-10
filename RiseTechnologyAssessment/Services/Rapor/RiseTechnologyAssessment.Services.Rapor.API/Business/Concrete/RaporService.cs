using System.Linq;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete
{
    public class RaporService:IRaporService
    {
        private readonly RaporContext _context;
        public RaporService(RaporContext context)
        {
            _context = context;
        }

        public string[] RaporListele()
        {
           return _context.Rapors.Select(x => x.KonumAd).ToArray();
        }
    }
}
