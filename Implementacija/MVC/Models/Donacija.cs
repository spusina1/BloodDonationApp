using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Donacija
    {
        public int DonacijaId { get; set; }

        [DisplayName("Datum doniranja")]
        public DateTime DatumDonacije { get; set; }
   
        public Donor Donor { get; set; }

        
        public KomponenteKrvi DoniraneKolicine { get; set; }

        [DisplayName("Donirane kolicine(L)")]
        public double DoniranaKolicinaKrvi { get; set; }

    }
}
