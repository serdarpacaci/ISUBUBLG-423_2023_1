using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Dtos
{
    public class SiparisDto : EntityDto
    {
        public string UserId { get; private set; }

        public AddressDto Address { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public List<SiparisItemDto> SiparisItems { get; set; }

    }
}
