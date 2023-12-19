namespace IsubuSatis.SepetService.Models
{
    public class SepetDto
    {
        public SepetDto()
        {
            Urunler = new List<SepetItemDto>();
        }

        public string UserId { get; set; }
        public List<SepetItemDto> Urunler { get; set; }

        public decimal SepetTutari => Urunler.Sum(x => x.Adet * x.Fiyat);
    }

    public class SepetItemDto
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public bool IsSeciliMi { get; set; }
    }

}
