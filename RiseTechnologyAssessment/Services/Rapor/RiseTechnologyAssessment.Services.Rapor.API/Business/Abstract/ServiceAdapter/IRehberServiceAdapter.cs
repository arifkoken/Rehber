using System.Threading.Tasks;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter
{
    public interface IRehberServiceAdapter
    {
        Task<KonumaGoreRaporDto> KonumaGoreRapor(int raporId, int konumId);
    }
}
