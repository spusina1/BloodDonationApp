using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Donacija
    {
        public int DonacijaId { get; set; }
        public DateTime DatumDonacije { get; set; }
        public int? DonorId { get; set; }
        public int? DoniraneKolicineKomponenteKrviId { get; set; }
        public double DoniranaKolicinaKrvi { get; set; }
        public int? ZavodId { get; set; }

        public virtual KomponenteKrvi DoniraneKolicineKomponenteKrvi { get; set; }
        public virtual Donor Donor { get; set; }
        public virtual Zavod Zavod { get; set; }
    }
}
