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

        public ComicController(IComicService svcComic)
        {
            this.svcComic = svcComic;
        }

        // GET: api/Comic
        [HttpGet]
        public IActionResult GetComic([FromQuery] ComicFilter filter)
        {
            var comics = svcComic.GetComics(
                filter,
                c => new 
                {
                    c.ComicID,
                    c.Title,
                    c.Description,
                    c.Pages,
                    c.Price,
                    c.Year,
                    c.Image
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
        [Route("{comicID}/image")]
        public IActionResult GetComicImageByComicID(int comicID)
        {
            var image = svcComic.GetComicImageByComicID(comicID)
                                       .Select(c => new
                                       {
                                           c.Name,
                                           c.Base64,
                                           c.Extension
                                       }).SingleOrDefault(); 
                
            return Ok(image);
        }


        [HttpGet]
        [Route("{comicID}/authors")]
        public IActionResult GetAuthorsByComicID(int comicID)
        {
            var authors = svcComic.GetAuthorsByComicID(comicID)
                                  .Select(c => new
                                       {
                                           c.AuthorID,
                                           c.Name
                                       })
                                  .ToList();
            return Ok(authors);
        }

        [HttpGet]
        [Route("{comicID}/genres")]
        public IActionResult GetGenresByComicID(int comicID)
        {
            var genres = svcComic.GetGenresByComicID(comicID)
                                  .Select(c => new
                                  {
                                      c.GenreID,
                                      c.Description
                                  })
                                  .ToList();
            return Ok(genres);
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
