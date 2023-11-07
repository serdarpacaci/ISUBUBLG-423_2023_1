using IsubuSatis.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IsubuSatis.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciKayit(KullaniciKayitDto input)
        {
            var eklenecekuser = new ApplicationUser
            {
                TcKimlikNo = input.TcKimlikNo,
                UserName = input.KullaniciAdi,
                Email = input.EPosta,
            };

            var result = await _userManager.CreateAsync(eklenecekuser, input.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return Ok();
        }
    }
}
