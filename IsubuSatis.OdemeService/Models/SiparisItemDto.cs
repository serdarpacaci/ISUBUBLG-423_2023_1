namespace IsubuSatis.OdemeService.Models
{
    public class SiparisItemDto 
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string FotografUrl { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
