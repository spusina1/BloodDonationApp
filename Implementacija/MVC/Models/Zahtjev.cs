using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public bool Odobren { get; set; }
        public double KolicinaKrvi { get; set; }
        public KomponenteKrvi KolicineKopmonenti{ get; set; }
        public KrvnaGrupa KrvnaGrupa { get; set; }
        
    }
}
