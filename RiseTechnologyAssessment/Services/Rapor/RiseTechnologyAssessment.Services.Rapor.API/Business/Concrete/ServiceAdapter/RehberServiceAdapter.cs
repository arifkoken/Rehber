using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete.ServiceAdapter
{
    public class RehberServiceAdapter : IRehberServiceAdapter
    {
        public async Task<KonumaGoreRaporDto> KonumaGoreRapor(int raporId, int konumId)
        {
            var client = new HttpClient();
            var response =
                await client.GetAsync("http://localhost:31089/api/Kisi/KonumaGoreRehberVerileri/" + raporId + "/" +
                                      konumId);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<KonumaGoreRaporDto>(content);
            return new KonumaGoreRaporDto() { RaporId = raporId, TopKisiSayisi = data.TopKisiSayisi, ToplamTelefonNoSayisi = data.ToplamTelefonNoSayisi };

        }
    }
}
