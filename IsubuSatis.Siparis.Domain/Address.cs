namespace IsubuSatis.Siparis.Domain
{
    public class Address
    {
        public string Sehir { get; private set; }

        

        public string Ilce { get; private set; }
        public string Mahalle { get; private set; }
        public string Cadde { get; private set; }
        public string BinaNo { get; private set; }
        public string DaireNo { get; private set; }

        public Address(string sehir, string ilce, string mahalle, 
            string cadde, string binaNo, string daireNo)
        {
            Sehir = sehir;
            Ilce = ilce;
            Mahalle = mahalle;
            Cadde = cadde;
            BinaNo = binaNo;
            DaireNo = daireNo;
        }
    }
}
