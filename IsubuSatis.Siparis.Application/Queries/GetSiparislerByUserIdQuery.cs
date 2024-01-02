using IsubuSatis.Siparis.Application.Dtos;
using MediatR;

namespace IsubuSatis.Siparis.Application.Queries
{
    public class GetSiparislerByUserIdQuery : IRequest<List<SiparisDto>>
    {
        public string UserId { get; set; }
    }
}
