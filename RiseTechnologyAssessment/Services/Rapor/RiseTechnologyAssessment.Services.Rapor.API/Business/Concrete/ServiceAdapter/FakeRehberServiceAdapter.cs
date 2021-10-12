using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete.ServiceAdapter
{
    public class FakeRehberServiceAdapter:IRehberServiceAdapter
    {
        public KonumaGoreRaporDto KonumaGoreRapor(int raporId,int konumId)
        {
            return new KonumaGoreRaporDto() {RaporId = raporId, TopKisiSayisi = 10, ToplamTelefonNoSayisi = 15};
        }
    }
}
