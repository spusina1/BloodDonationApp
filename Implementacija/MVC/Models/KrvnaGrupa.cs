using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BloodDonationApplication.Models
{
    public class KrvnaGrupa
    {
        public int KrvnaGrupaId { get; set; }

        [DisplayName("Naziv krvne grupe")]
        public string Naziv { get; set; }
    }
}
