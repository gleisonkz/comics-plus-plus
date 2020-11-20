using ComicStore.Application.DTO;
using ComicStore.Domain.POCO;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: api/Author
        [HttpGet]
        public async Task<IActionResult> GetAuthor()
        {
            var authors =
                await svcAuthor.GetAuthor()
                .Select(c => new
                {
                    c.AuthorID,
                    c.Name,
                })
                .ToListAsync();
                return Ok(authors);
        }
    }
}
