using ComicStore.Application.DTO;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        
        [HttpGet]
        [Route("{id}/authors")]
        public async Task<IActionResult> GetAtuhors(int comicID)
        {
            var authors =
               await svcComic.GetComic()
                   .Where(c=> c.ComicID == comicID)
                   .SelectMany(c=> c.Authors)
                   .Select(c=> new
                   {
                      c.AuthorID,
                      c.Name
                   })
                   .ToListAsync();
            return Ok(authors);
        }

        [HttpPost]
        public IActionResult PostComic([FromBody] ComicDTO comicDTO)
        {
            try
            {
                var comic = svcComic.CreateComic(comicDTO);
                svcComic.Commit();
                return Ok(comicDTO);
            }
            catch (Exception ex)
            {
                svcComic.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
