using System;
using System.Collections.Generic;

namespace BloodDonationApplicationAPI.Models
{
    public partial class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public bool Odobren { get; set; }
        public double KolicinaKrvi { get; set; }
        public int? KolicineKopmonentiKomponenteKrviId { get; set; }
        public int? KrvnaGrupaId { get; set; }
        public int? KlinikaId { get; set; }
        public int? ZavodId { get; set; }

        public virtual Klinika Klinika { get; set; }
        public virtual KomponenteKrvi KolicineKopmonentiKomponenteKrvi { get; set; }
        public virtual KrvnaGrupa KrvnaGrupa { get; set; }
        public virtual Zavod Zavod { get; set; }
    }
}
