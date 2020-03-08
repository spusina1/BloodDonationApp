using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Klinika
    {
        public Klinika()
        {
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int KlinikaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
