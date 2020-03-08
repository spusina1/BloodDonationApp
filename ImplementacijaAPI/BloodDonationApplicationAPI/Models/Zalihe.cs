using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Zalihe
    {
        public int ZaliheId { get; set; }
        public double Eritrociti { get; set; }
        public double Trombociti { get; set; }
        public double Leukociti { get; set; }
        public double KrvnaPlazma { get; set; }
        public double Krv { get; set; }
        public int? KrvnaGrupaId { get; set; }
        public int? ZavodId { get; set; }

        public virtual KrvnaGrupa KrvnaGrupa { get; set; }
        public virtual Zavod Zavod { get; set; }
    }
}
