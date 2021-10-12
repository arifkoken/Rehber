using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete.ServiceAdapter
{
    public class RehberServiceAdapter : IRehberServiceAdapter
    {
        private IConfiguration _configuration;
        public RehberServiceAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<KonumaGoreRaporDto> KonumaGoreRapor(int raporId, int konumId)
        {
            var client = new HttpClient();
            var response =
                await client.GetAsync(_configuration["RehberKonumDetayEndPointAdres"] + raporId + "/" + konumId);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<KonumaGoreRaporDto>(content);
            return new KonumaGoreRaporDto() { RaporId = raporId, TopKisiSayisi = data.TopKisiSayisi, ToplamTelefonNoSayisi = data.ToplamTelefonNoSayisi };

        }
    }
}
