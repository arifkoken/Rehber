using System.Collections.Generic;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Db
{
    public partial class Konum
    {
        public Konum()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
