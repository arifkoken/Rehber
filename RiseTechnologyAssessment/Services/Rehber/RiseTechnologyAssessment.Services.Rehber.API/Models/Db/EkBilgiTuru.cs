using System.Collections.Generic;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Db
{
    public partial class EkBilgiTuru
    {
        public EkBilgiTuru()
        {
            EkBilgis = new HashSet<EkBilgi>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<EkBilgi> EkBilgis { get; set; }
    }
}
