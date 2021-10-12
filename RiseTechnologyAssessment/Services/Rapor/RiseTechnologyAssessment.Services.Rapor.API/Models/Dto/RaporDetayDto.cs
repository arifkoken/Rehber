using System;

namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Dto
{
    public class RaporDetayDto
    {
        public int RaporId { get; set; }
        public int KonumId { get; set; }
        public string KonumAd { get; set; }
        public int ToplamKisiSayisi { get; set; }
        public int ToplamTelefonNoSayisi { get; set; }
        public DateTime TalepZamani { get; set; }
        public DateTime OlusturmaZamani { get; set; }
        public string Durum { get; set; }

    }
}
