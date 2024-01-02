namespace IsubuSatis.OdemeService.Models
{
    public class OdemeDto
    {
        public string AdSoyad { get; set; }
        public string KartNo { get; set; }
        public string Ay { get; set; }
        public string Yil { get; set; }
        public string Cvv { get; set; }
        public decimal Fiyat { get; set; }

        public SiparisDto Siparis { get; set; }
    }
}
