using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class Zavod
    {

     
        public int ZavodId { get; set; }
        public string Naziv { get; set; }
      
        public List<Donor> ListaDonora { get; set; }
        public List<Donacija> ListaDonacija { get; set; }
        public List<Zahtjev> ListaZahtjeva { get; set; }
        public string Grad { get; set; }
        public List<Zalihe> ZaliheKomponente { get; set; } //stoji lista na dijagramu greska?
      

    }
}
