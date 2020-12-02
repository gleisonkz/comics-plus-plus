using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService svcAuthor;

        public AuthorController(IAuthorService svcAuthor)
        {
            this.svcAuthor = svcAuthor;
        }

        public IActionResult GetAuthor([FromQuery] AuthorFilter filter)
        {
            Paginator<dynamic> authors = svcAuthor.GetPaginatedAuthors(
                filter,
                c => new
                {
                    c.AuthorID,
                    c.Name
                });

            var result = authors.ToList();

            Response.Headers.Add(
                "X-Pagination",
                 JsonConvert.SerializeObject(authors.GetPaginatorMetadata(), new JsonSerializerSettings
                 {
                     ContractResolver = new DefaultContractResolver
                     {
                         NamingStrategy = new CamelCaseNamingStrategy()
                     }
                 })
                 );

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostGenre([FromBody] AuthorDTO authorDTO)
        {
            try
            {
                var genre = svcAuthor.CreateAuthor(authorDTO);
                svcAuthor.Commit();
                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                svcAuthor.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPut("{authorID}")]
        public IActionResult PutGenre(int authorID, [FromBody] AuthorDTO authorDTO)
        {
            try
            {
                authorDTO.AuthorID = authorID;
                svcAuthor.UpdateAuthor(authorDTO);
                svcAuthor.Commit();
                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                svcAuthor.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{authorID}")]
        public IActionResult DeleteGenre(int authorID)
        {
            try
            {
                svcAuthor.DeleteAuthor(authorID);
                svcAuthor.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                svcAuthor.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
