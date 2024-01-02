namespace IsubuSatis.Siparis.Application.Dtos
{
    public class AddressDto : EntityDto
    {
        public string Sehir { get; private set; }
        public string Ilce { get; private set; }
        public string Mahalle { get; private set; }
        public string Cadde { get; private set; }
        public string BinaNo { get; private set; }
        public string DaireNo { get; private set; }

    }
}
