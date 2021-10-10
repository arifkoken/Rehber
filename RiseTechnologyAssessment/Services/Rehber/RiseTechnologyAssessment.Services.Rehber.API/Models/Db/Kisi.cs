using System.Collections.Generic;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Db
{
    public partial class Kisi
    {
        public Kisi()
        {
            EkBilgis = new HashSet<EkBilgi>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public int KonumId { get; set; }

        public virtual Konum Konum { get; set; }
        public virtual ICollection<EkBilgi> EkBilgis { get; set; }
    }
}
