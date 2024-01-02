using IsubuSatis.Siparis.Application.Dtos;
using IsubuSatis.Siparis.Application.Mapping;
using IsubuSatis.Siparis.Application.Queries;
using IsubuSatis.Siparis.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IsubuSatis.Siparis.Application.Handlers
{
    public class GetSiparislerbyUserIdQueryHandler : IRequestHandler<GetSiparislerByUserIdQuery, List<SiparisDto>>
    {
        private readonly SiparisDbContext _siparisDbContext;

        public GetSiparislerbyUserIdQueryHandler(SiparisDbContext siparisDbContext)
        {
            _siparisDbContext = siparisDbContext;
        }

        public async Task<List<SiparisDto>> Handle(GetSiparislerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var siparisler = await _siparisDbContext.Siparisler
                .Include(x => x.SiparisItems)
                .Include(x => x.Address)
                .Where(x => x.UserId == request.UserId)
                .ToListAsync();

            var siparislerDto = IsubuObjectMapper.Mapper.Map<List<SiparisDto>>(siparisler);

            return siparislerDto;
        }
    }
}
