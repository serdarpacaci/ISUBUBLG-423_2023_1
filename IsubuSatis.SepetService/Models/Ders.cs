namespace IsubuSatis.SepetService.Models
{
    public class Ders
    {
        public string DersAdi { get; set; }
        public DateTime OlusturmaZamani { get; set; }

        public Guid Id { get; set; }

        public Ders(Guid id, string dersAdi)
        {
            Id = id;
            DersAdi = dersAdi;
            OlusturmaZamani = DateTime.Now;

        }
    }
}
