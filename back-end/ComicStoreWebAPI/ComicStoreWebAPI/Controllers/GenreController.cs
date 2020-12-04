using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using ComicStore.Shared.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

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

        [HttpGet]
        [Route("paginator")]
        public IActionResult GetGenre([FromQuery] GenreFilter filter)
        {
            try
            {
                Paginator<dynamic> genres = svcGenre.GetPaginatedGenres(
                    filter,
                    c => new GenreDTO
                    {
                        GenreID = c.GenreID,
                        Description = c.Description
                    });

                var result = genres.ToList();

                Response.Headers.Add(
                    "X-Pagination",
                     JsonConvert.SerializeObject(genres.GetPaginatorMetadata(), new JsonSerializerSettings
                     {
                         ContractResolver = new DefaultContractResolver
                         {
                             NamingStrategy = new CamelCaseNamingStrategy()
                         }
                     })
                     );

                return Ok(result);
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{description}")]
        public IActionResult GetAuthorsByName(string description)
        {
            try
            {
                var genres = svcGenre.GetGenresByName(description)
                         .Select(c => new
                         {
                             c.GenreID,
                             c.Description
                         }).ToList();

                return Ok(genres);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostGenre([FromBody] GenreDTO genreDTO)
        {
            try
            {
                var genre = svcGenre.CreateGenre(genreDTO);
                svcGenre.Commit();
                return Ok(genreDTO);
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{genreID}")]
        public IActionResult PutGenre(int genreID, [FromBody] GenreDTO genreDTO)
        {
            try
            {
                genreDTO.GenreID = genreID;
                svcGenre.UpdateGenre(genreDTO);
                svcGenre.Commit();
                return Ok(genreDTO);
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{genreID}")]
        public IActionResult DeleteGenre(int genreID)
        {
            try
            {
                svcGenre.DeleteGenre(genreID);
                svcGenre.Commit();
                return Ok();
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{genreID}/relationships")]
        public IActionResult DeleteGenreRelationships(int genreID)
        {
            try
            {
                svcGenre.DeleteGenreRelationships(genreID);
                svcGenre.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
