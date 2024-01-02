using IsubuSatis.Siparis.Application.Dtos;
using MediatR;

namespace IsubuSatis.Siparis.Application.Command
{
    public class CreateSiparisCommand : IRequest<CreateSiparisDto>
    {
        public string UserId { get; set; }
        public List<SiparisItemDto> SiparisItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
