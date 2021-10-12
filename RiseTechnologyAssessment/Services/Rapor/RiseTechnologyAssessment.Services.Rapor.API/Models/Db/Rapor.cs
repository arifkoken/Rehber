using System;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Db
{
    public partial class Rapor
    {
        public int Id { get; set; }
        public int KonumId { get; set; }
        public string KonumAd { get; set; }
        public int? ToplamKisiSayisi { get; set; }
        public int? ToplamTelefonNoSayisi { get; set; }
        public DateTime TalepZamani { get; set; }
        public DateTime? OlusturmaZamani { get; set; }
    }
}
