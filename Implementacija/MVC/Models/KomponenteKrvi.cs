using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication.Models
{
    public class KomponenteKrvi
    {
        public int KomponenteKrviId { get; set; } //ne znam da li treba
        public double Eritrociti { get; set; }
        public double Trombociti { get; set; }
        public double Leukociti { get; set; }
        public double KrvnaPlazma { get; set; }
    }
}
