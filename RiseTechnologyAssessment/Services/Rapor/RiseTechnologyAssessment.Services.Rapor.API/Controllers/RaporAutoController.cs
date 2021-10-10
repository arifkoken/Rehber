using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaporAutoController : ControllerBase
    {
        [HttpPost]
        public void Talep([FromBody] RaporTalepDto model)
        {
            //Todo Talebi Db'ye kaydet
            //Todo Rabit MQ ya rapor oluştur kaydı gir
            //Todo Db'ye kaydedememe ve kuyruga atamama istisnai durumları değerlendirilmesi gerekiyor.
            //Todo Kuyruktan talepleri alıp rapor oluşturan bir consumer projesi solutiona dahil edilecek.
        }

        [HttpGet]
        public IEnumerable<RaporListDto> Listele()
        {
            //Todo Talepler Db'den çekilecek(List<RaporListDto>())
            //Todo Rapor Tablosundaki Oluşturma Zamani NULL ise Durum:Hazırlanıyor NULL Degilse Durum:Tamamlandı olarak set edilecek
            
            return new List<RaporListDto>() { };
        }


        [HttpGet("{id}")]
        public RaporDetayDto Detay(int id)
        {

            //Todo  Raporun Hazırlanıp hazırlanılmadığı bilgisi kontrol edilecek(Oluşturma Zamanı üzerinden) Hazırlanmışsa rapor detayı hazırlanmamışsa hazırlanmamış bilgisi döndürülecek.
            return new RaporDetayDto() { };
        }

    }
}
