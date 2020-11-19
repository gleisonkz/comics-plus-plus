using ComicStore.Domain.POCO;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            ICollection<Genre> genres = await svcGenre.GetGenre().ToListAsync();
            return Ok(genres);
        }
    }
}
