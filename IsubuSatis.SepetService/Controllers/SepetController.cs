using IsubuSatis.SepetService.Models;
using IsubuSatis.SepetService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SepetController : ControllerBase
    {
        private readonly ISepetService _sepetService;
        private readonly IIdentityHelperService _identityHelperService;

        public SepetController(IIdentityHelperService identityHelperService, ISepetService sepetService)
        {
            _identityHelperService = identityHelperService;
            _sepetService = sepetService;
        }


        [HttpGet]
        public async Task<IActionResult> GetSepet()
        {
            var userClaims = User.Claims;
            var userId = _identityHelperService.GetUserId();// "123456";

            var sepet = await _sepetService.GetSepet(userId);

            return Ok(sepet);
        }

        [HttpPost]
        public async Task<IActionResult> KaydetVeyaGuncelle(SepetDto sepet)
        {
            sepet.UserId = _identityHelperService.GetUserId();// "123456";
            await _sepetService.SepetKaydet(sepet);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Sil()
        {
            var userId = _identityHelperService.GetUserId();// "123456";
            
            await _sepetService.Sil(userId);

            return Ok();
        }
    }
}
