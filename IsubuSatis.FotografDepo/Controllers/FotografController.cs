using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.FotografDepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FotografController : ControllerBase
    {
        private readonly string _fotografKlasoru;

        private List<string> _izinVerilenFormatlar = new List<string>()
        {
            "image/png",
            "image/jpeg",
            "image/jpg",
            "image/gif",
        };

        public FotografController()
        {
            _fotografKlasoru = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        }


        //[HttpPost]
        //public IActionResult Kaydet(IFormFile fotograf)
        //{
        //    if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x => x == fotograf.ContentType))
        //        return BadRequest();
            
        //    var extension = Path.GetExtension(fotograf.FileName);
        //    var randomFileName = Path.GetRandomFileName();
        //    randomFileName = Path.ChangeExtension(randomFileName, extension);

        //    var fotografPath = Path.Combine(_fotografKlasoru, randomFileName);
        //    using var stream = new FileStream(fotografPath, FileMode.Create);

        //    fotograf.CopyTo(stream);

        //    return Ok();
        //}


        [HttpPost]
        public async Task<IActionResult> Kaydet(IFormFile fotograf, 
            CancellationToken cancellationToken)
        {
            if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x => x == fotograf.ContentType))
                return BadRequest();

            var extension = Path.GetExtension(fotograf.FileName);
            var randomFileName = Path.GetRandomFileName();
            randomFileName = Path.ChangeExtension(randomFileName, extension);

            var fotografPath = Path.Combine(_fotografKlasoru, randomFileName);
            using var stream = new FileStream(fotografPath, FileMode.Create);

            await fotograf.CopyToAsync(stream, cancellationToken);

            //if (cancellationToken.IsCancellationRequested && System.IO.File.Exists(fotografPath))
            //{
            //    System.IO.File.Delete(fotografPath);
            //}
                

            return Ok(new { Filename = randomFileName });
        }

        [HttpDelete]
        public IActionResult Sil(string fileName)
        {
            var path = Path.Combine(_fotografKlasoru, fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Ok();
        }
    }
}
