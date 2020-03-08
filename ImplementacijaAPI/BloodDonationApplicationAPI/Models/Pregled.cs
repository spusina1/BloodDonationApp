using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Pregled
    {
        public int PregledId { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string DetaljiPregleda { get; set; }
        public bool UspjesanPregled { get; set; }
        public int? LabNalazIdLaboratorijskiNalazId { get; set; }
        public int? DonorId { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual LaboratorijskiNalaz LabNalazIdLaboratorijskiNalaz { get; set; }
    }
}
