using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Zavod
    {
        public Zavod()
        {
            Donacija = new HashSet<Donacija>();
            Donor = new HashSet<Donor>();
            Zahtjev = new HashSet<Zahtjev>();
            Zalihe = new HashSet<Zalihe>();
        }

        public int ZavodId { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }

        public virtual ICollection<Donacija> Donacija { get; set; }
        public virtual ICollection<Donor> Donor { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
        public virtual ICollection<Zalihe> Zalihe { get; set; }
    }
}
