using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class LaboratorijskiNalaz
    {
        public int LaboratorijskiNalazId { get; set; }
        public KomponenteKrvi KomponenteKrvi { get; set; }
        public double Hemoglobin { get; set; }
        public double Glukoza { get; set; }
        public double Holesterol { get; set; }
        public double Trigliceridi { get; set; }
        public double Zeljezo { get; set; }
       
    }
}
