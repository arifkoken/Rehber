using System.Collections.Generic;

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto
{
    public class KisiDetayDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public int KonumId { get; set; }
        public string KonumAd { get; set; }
        public List<KisiEkBilgiDetayDto> EkBilgiListesi { get; set; }
    }
}
