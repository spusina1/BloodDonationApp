using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
    }
}
