using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class KrvnaGrupa
    {
        public KrvnaGrupa()
        {
            Donor = new HashSet<Donor>();
            Zahtjev = new HashSet<Zahtjev>();
            Zalihe = new HashSet<Zalihe>();
        }

        public int KrvnaGrupaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Donor> Donor { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
        public virtual ICollection<Zalihe> Zalihe { get; set; }
    }
}
