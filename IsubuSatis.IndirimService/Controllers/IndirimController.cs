using IsubuSatis.IndirimService.Models;
using IsubuSatis.IndirimService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.IndirimService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndirimController : ControllerBase
    {

        private readonly IIndirimService _indirimService;

        public IndirimController(IIndirimService indirimService)
        {
            _indirimService = indirimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _indirimService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetbyId(int id)
        {
            return Ok(await _indirimService.GetbyId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Kaydet(Indirim indirim)
        {
            await _indirimService.Kaydet(indirim);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Guncelle(Indirim indirim)
        {
            await _indirimService.Guncelle(indirim);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Sil(int id)
        {
            await _indirimService.Sil(id);
            return Ok();
        }
    }
}
