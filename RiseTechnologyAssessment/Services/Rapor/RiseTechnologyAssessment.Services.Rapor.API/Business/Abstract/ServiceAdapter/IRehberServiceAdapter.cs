using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter
{
    public interface IRehberServiceAdapter
    {
        KonumaGoreRaporDto KonumaGoreRapor(int raporId, int konumId);
    }
}
