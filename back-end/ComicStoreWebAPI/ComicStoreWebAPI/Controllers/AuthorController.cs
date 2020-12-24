using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ComicStoreBaseController
    {
        private readonly IAuthorService svcAuthor;

        public AuthorController(IAuthorService svcAuthor)
        {
            this.svcAuthor = svcAuthor;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("paginator")]
        public IActionResult GetPaginatedAuthors([FromQuery] AuthorFilter filter)
        {
            Paginator<dynamic> authors = svcAuthor.GetPaginatedAuthors(
                filter,
                c => new
                {
                    c.AuthorID,
                    c.Name
                });

            var result = authors.ToList();

            AddPaginationHeader(authors);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PostAuthor([FromBody] AuthorDTO authorDTO)
        {
            try
            {
                var author = svcAuthor.CreateAuthor(authorDTO);
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
        [Authorize(Roles = "Admin")]
        public IActionResult PutAuthor(int authorID, [FromBody] AuthorDTO authorDTO)
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
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAuthor(int authorID)
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

        [HttpGet("{name}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAuthorsByName(string name)
        {
            try
            {
                var authors = svcAuthor.GetAuthorsByName(name)
                         .Select(c => new
                         {
                             c.AuthorID,
                             c.Name
                         }).ToList();

                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }


}
