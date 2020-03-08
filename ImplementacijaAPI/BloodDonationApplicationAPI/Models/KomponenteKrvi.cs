using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class KomponenteKrvi
    {
        public KomponenteKrvi()
        {
            Donacija = new HashSet<Donacija>();
            LaboratorijskiNalaz = new HashSet<LaboratorijskiNalaz>();
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int KomponenteKrviId { get; set; }
        public double Eritrociti { get; set; }
        public double Trombociti { get; set; }
        public double Leukociti { get; set; }
        public double KrvnaPlazma { get; set; }

        public virtual ICollection<Donacija> Donacija { get; set; }
        public virtual ICollection<LaboratorijskiNalaz> LaboratorijskiNalaz { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
