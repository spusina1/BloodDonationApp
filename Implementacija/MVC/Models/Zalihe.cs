namespace BloodDonationApplication.Models
{
    public class Zalihe
    {
        public int ZaliheId {get; set;}
        public double Eritrociti { get; set; }
        public double Trombociti { get; set; }
        public double Leukociti { get; set; }
        public double KrvnaPlazma { get; set; }
        public double Krv { get; set; }
        public KrvnaGrupa KrvnaGrupa { get; set; }
    }
}