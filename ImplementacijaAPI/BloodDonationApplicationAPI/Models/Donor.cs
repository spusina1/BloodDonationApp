using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Donor
    {
        public Donor()
        {
            Donacija = new HashSet<Donacija>();
            Pregled = new HashSet<Pregled>();
        }

        public int DonorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Jmbg { get; set; }
        public int? KrvnaGrupaId { get; set; }
        public string BrojMobilnogTelefona { get; set; }
        public string Grad { get; set; }
        public int? ZavodId { get; set; }

        public virtual KrvnaGrupa KrvnaGrupa { get; set; }
        public virtual Zavod Zavod { get; set; }
        public virtual ICollection<Donacija> Donacija { get; set; }
        public virtual ICollection<Pregled> Pregled { get; set; }
    }
}
