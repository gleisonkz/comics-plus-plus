using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Domain.POCO;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IComicService svcComic;
        private ComicStoreDbContext context;

        public ComicController(IComicService svcComic, ComicStoreDbContext context)
        {
            this.svcComic = svcComic;
            this.context = context;
        }

        // GET: api/Comic
        [HttpGet]
        public IActionResult GetComic([FromQuery] ComicFilter filter)
        {
            var comic = svcComic.GetComic().ToList();

            var comics = svcComic.GetComics(
                filter,
                c => new ComicDTO
                {
                    ComicID = filter.ComicID,
                    Title = filter.Title,
                    Description = filter.Description,
                    Pages = filter.Pages,
                    Price = filter.Price,
                    Year = filter.Year,
                    Authors = filter.Authors,
                    Genres = filter.Genres
                });

            var result = comics.ToList();

            Response.Headers.Add(
                "X-Pagination",
                 JsonConvert.SerializeObject(comics.GetPaginatorMetadata(), new JsonSerializerSettings
                 {
                     ContractResolver = new DefaultContractResolver
                     {
                         NamingStrategy = new CamelCaseNamingStrategy()
                     }
                 })
                 );

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
