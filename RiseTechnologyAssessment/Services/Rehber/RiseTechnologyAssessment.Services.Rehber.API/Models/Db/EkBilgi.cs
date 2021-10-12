#nullable disable

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Db
{
    public partial class EkBilgi
    {
        public int Id { get; set; }
        public int KisiId { get; set; }
        public int EkBilgiTuruId { get; set; }
        public string Deger { get; set; }
        public virtual EkBilgiTuru EkBilgiTuruNavigation { get; set; }
        public virtual Kisi Kisi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
