using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IComicService svcComic;

        public ComicController(IComicService svcComic)
        {
            this.svcComic = svcComic;
        }

        // GET: api/Comic
        [HttpGet]
        public async Task<IActionResult> GetComic()
        {
            var comics =
               await svcComic.GetComic()
                   .Select(c => new
                   {
                       c.ComicID,
                       c.Title,
                       c.Description,
                       c.Price,
                       c.Year,
                       c.Pages
                   })
               .ToListAsync();
            return Ok(comics);
        }
    }
}
