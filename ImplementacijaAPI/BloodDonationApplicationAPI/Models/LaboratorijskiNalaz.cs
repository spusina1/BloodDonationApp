using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class LaboratorijskiNalaz
    {
        public LaboratorijskiNalaz()
        {
            Pregled = new HashSet<Pregled>();
        }

        public int LaboratorijskiNalazId { get; set; }
        public int? KomponenteKrviId { get; set; }
        public double Hemoglobin { get; set; }
        public double Glukoza { get; set; }
        public double Holesterol { get; set; }
        public double Trigliceridi { get; set; }
        public double Zeljezo { get; set; }

        public virtual KomponenteKrvi KomponenteKrvi { get; set; }
        public virtual ICollection<Pregled> Pregled { get; set; }
    }
}
