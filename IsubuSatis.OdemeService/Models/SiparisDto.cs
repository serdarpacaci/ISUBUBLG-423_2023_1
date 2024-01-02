namespace IsubuSatis.OdemeService.Models
{
    public class SiparisDto 
    {
        public string UserId { get; private set; }

        public AddressDto Address { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public List<SiparisItemDto> SiparisItems { get; set; }

    }
}
