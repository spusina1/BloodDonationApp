using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }

        [DisplayName("Korisničko ime")]
        public string KorisnickoIme { get; set; }

        [DisplayName("Šifra")]
        public string sifra { get; set; }
    }
}
