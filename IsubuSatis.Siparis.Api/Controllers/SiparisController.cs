using IsubuSatis.Siparis.Api.Services;
using IsubuSatis.Siparis.Application.Command;
using IsubuSatis.Siparis.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.Siparis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityHelperService _identityHelperService;
        public SiparisController(IMediator mediator, 
            IIdentityHelperService identityHelperService)
        {
            _mediator = mediator;
            _identityHelperService = identityHelperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSiparisler()
        {
            var sonuc = await _mediator.Send(new GetSiparislerByUserIdQuery
            {
                UserId = _identityHelperService.GetUserId()
            });

            return Ok(sonuc);
        }



        [HttpPost]
        public async Task<IActionResult> SiparisKaydet(CreateSiparisCommand createSiparisCommand)
        {
            var sonuc = await _mediator.Send(createSiparisCommand);

            return Ok(sonuc);
        }


    }
}
