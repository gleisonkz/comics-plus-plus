using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService svcGenre;

        public GenreController(IGenreService svcGenre)
        {
            this.svcGenre = svcGenre;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<IActionResult> GetGenre()
        {
            var genres =
               await svcGenre.GetGenre()
               .Select(c => new
               {
                   c.Description,
                   c.GenreID
               })
               .ToListAsync();
            return Ok(genres);
        }
    }
}
