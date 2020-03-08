using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Klinika
    {
        public int KlinikaId { get; set; }
        public string Naziv { get; set; }
        public List<Zahtjev> Zahtjevi { get; set; }
        
    }
}
