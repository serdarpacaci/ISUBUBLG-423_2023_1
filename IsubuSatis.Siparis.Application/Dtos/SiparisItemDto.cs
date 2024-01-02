namespace IsubuSatis.Siparis.Application.Dtos
{
    public class SiparisItemDto : EntityDto
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string FotografUrl { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
