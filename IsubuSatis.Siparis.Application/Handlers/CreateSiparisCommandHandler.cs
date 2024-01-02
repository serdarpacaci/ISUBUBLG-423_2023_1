using IsubuSatis.Siparis.Application.Command;
using IsubuSatis.Siparis.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Handlers
{
    public class CreateSiparisCommandHandler : IRequestHandler<CreateSiparisCommand, CreateSiparisDto>
    {
        public async Task<CreateSiparisDto> Handle(CreateSiparisCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
