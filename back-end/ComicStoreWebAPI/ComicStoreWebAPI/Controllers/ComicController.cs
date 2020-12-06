using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using ComicStore.Shared.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

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

        [HttpGet("{comicID}")]
        public IActionResult GetComicByID(int comicID)
        {
            try
            {
                var comic = svcComic.GetComicByID(comicID)
                                    .Select(c => new ComicDTO
                                    {
                                        ComicID = c.ComicID,
                                        Title = c.Title,
                                        Description = c.Description,
                                        Price = c.Price,
                                        Year = c.Year,
                                        Pages = c.Pages,
                                        Image = new ComicImageInfo
                                        {
                                            Name = c.Image.Name,
                                            Extension = c.Image.Extension,
                                            Base64 = c.Image.Base64

                                        },
                                        Authors = c.Authors.Select(d =>
                                                            new KeyValueAuthor { AuthorID = d.AuthorID, Name = d.Name })
                                                           .ToList(),
                                        Genres = c.Genres.Select(d =>
                                                            new KeyValueGenre { GenreID = d.GenreID, Description = d.Description })
                                                         .ToList(),
                                    })
                                    .SingleOrDefault();

                return Ok(comic);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("shop-item")]
        public IActionResult GetComicsShopItems()
        {
            try
            {
                var comics = svcComic.GetComic()
                                    .Select(c => new
                                    {
                                        c.ComicID,
                                        c.Title,
                                        c.Description,
                                        c.Price,
                                        Image = new ComicImageInfo
                                        {
                                            Name = c.Image.Name,
                                            Extension = c.Image.Extension,
                                            Base64 = c.Image.Base64
                                        },      
                                        Authors = c.Authors.Select(c=> c.Name).ToList(),
                                        Genres = c.Genres.Select(c=> c.Description).ToList()
                                    })
                                    .ToList();

                return Ok(comics);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{comicID}/shop-item")]
        public IActionResult GetComicShopItemDetailByID(int comicID)
        {
            try
            {
                var comics = svcComic.GetComic()
                                     .Where(c=> c.ComicID == comicID)
                                     .Select(c => new
                                        {
                                            c.ComicID,
                                            c.Title,
                                            c.Description,
                                            c.Price,
                                            c.Pages,
                                            c.Year,
                                            Image = new ComicImageInfo
                                            {
                                                Name = c.Image.Name,
                                                Extension = c.Image.Extension,
                                                Base64 = c.Image.Base64
                                            },
                                            Authors = c.Authors.Select(c => c.Name).ToList(),
                                            Genres = c.Genres.Select(c => c.Description).ToList()
                                        })
                                     .SingleOrDefault();

                return Ok(comics);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("paginator")]
        public IActionResult GetPaginatedComics([FromQuery] ComicFilter filter)
        {
            try
            {
                Paginator<dynamic> comics = svcComic.GetPaginatedComics(
                    filter,
                    c => new
                    {
                        c.ComicID,
                        c.Title,
                        c.Description,
                        c.Pages,
                        c.Price,
                        c.Year,
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

                return Ok(result);
            }
            catch (CustomException ex)
            {
                svcComic.Rollback();
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                svcComic.Rollback();
                return BadRequest(ex.Message);
            }
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
        [Route("{comicID}/author")]
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
        [Route("{comicID}/genre")]
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
        public IActionResult PostComic([FromBody] SaveComicDTO comicDTO)
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

        [HttpPut("{comicID}")]
        public IActionResult PutComic(int comicID, [FromBody] SaveComicDTO comicDTO)
        {
            try
            {
                svcComic.UpdateComic(comicDTO, comicID);
                svcComic.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                svcComic.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{comicID}")]
        public IActionResult DeleteComic(int comicID)
        {
            try
            {
                svcComic.DeleteComic(comicID);
                svcComic.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                svcComic.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
