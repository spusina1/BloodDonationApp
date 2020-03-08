using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Pregled
    {
        public int PregledId { get; set; }

        [DisplayName("Datum pregleda")]
        public DateTime DatumPregleda { get; set; }

        [DisplayName("Detalji pregleda")]
        public string DetaljiPregleda { get; set; }

        [DisplayName("Uspješan pregled")]
        public bool UspjesanPregled { get; set; }
        public LaboratorijskiNalaz LabNalazId { get; set; }
    }
}
