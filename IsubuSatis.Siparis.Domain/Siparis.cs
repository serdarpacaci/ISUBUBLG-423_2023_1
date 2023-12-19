using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Domain
{
    public class Siparis : Entity
    {
        public string UserId { get; private set; }

        public Address Address { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public List<SiparisItem> SiparisItems { get; set; }


        public decimal SiparisTutari => SiparisItems.Sum(x => x.Adet * x.Fiyat);

        public void SiparisItemEkle(SiparisItem siparisItem)
        {
            var mevcutUrun = SiparisItems.Any(x => x.UrunId == siparisItem.UrunId);
            if (!mevcutUrun)
            {
                SiparisItems.Add(siparisItem);
            }
            else
            {

            }
        }
        public Siparis(string userId, Address address)
        {
            UserId = userId;
            Address = address;
            SiparisTarihi = DateTime.Now;

            SiparisItems = new List<SiparisItem>();
        }
    }

    public class SiparisItem : Entity
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
