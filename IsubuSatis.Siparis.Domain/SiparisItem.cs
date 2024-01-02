namespace IsubuSatis.Siparis.Domain
{
    public class SiparisItem : Entity
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
