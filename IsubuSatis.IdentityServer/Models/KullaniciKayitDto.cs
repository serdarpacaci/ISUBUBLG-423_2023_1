using System.ComponentModel.DataAnnotations;

namespace IsubuSatis.IdentityServer.Models
{
    public class KullaniciKayitDto
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [EmailAddress]
        public string EPosta { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string TcKimlikNo { get; set; }
    }
}
