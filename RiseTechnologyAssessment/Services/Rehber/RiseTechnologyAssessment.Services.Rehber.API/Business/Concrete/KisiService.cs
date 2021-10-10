using System.Linq;
using RiseTechnologyAssessment.Services.Rehber.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rehber.API.Business.Concrete
{
    public class KisiService:IKisiService
    {
        private readonly RehberContext _context;
        public KisiService(RehberContext context)
        {
            _context = context;
        }

        public string[] KonumListele()
        {
           return _context.Konums.Select(x => x.Ad).ToArray();
        }
    }
}
