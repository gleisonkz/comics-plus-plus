using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using ComicStore.Shared.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ComicStoreBaseController
    {
        private readonly IComicService svcComic;

        public ComicController(IComicService svcComic)
        {
            this.svcComic = svcComic;
        }

        [HttpGet("{comicID}")]
        public async Task<IActionResult> GetComicByID(int comicID)
        {
            try
            {
                ComicDTO comic = await svcComic.FindAsync<Comic>(comicID);
                return Ok(comic);
            }
            catch (ArgumentNullException)
            {
                return NotFound(comicID);
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
                                         InventoryQuantity = c.Inventory.Quantity,
                                         Authors = c.Authors.Select(c => c.Name).ToList(),
                                         Genres = c.Genres.Select(c => c.Description).ToList()
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
                                     .Where(c => c.ComicID == comicID)
                                     .Select(c => new
                                     {
                                         c.ComicID,
                                         c.Title,
                                         c.Description,
                                         c.Price,
                                         c.Pages,
                                         c.Year,
                                         InventoryQuantity = c.Inventory.Quantity,
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

                AddPaginationHeader(comics);

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
        [ResponseCache(Duration = 3600)]
        public IActionResult GetComicImageByComicID(int comicID)
        {

            var image = svcComic.GetComicImageByComicID(comicID)
                                       .Select(c => new
                                       {
                                           c.Base64,
                                           c.Extension
                                       }).SingleOrDefault();

            return File(image.Base64, $"image/{image.Extension}");
        }

        [HttpGet]
        [Route("{comicID}/author")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpGet]
        [Route("inventory/paginator")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPaginatedComicsInventory([FromQuery] ComicInventoryFilter filter)
        {
            try
            {
                Paginator<dynamic> comicsInventory = svcComic.GetPaginatedComicsInventory(
                    filter,
                    c => new
                    {
                        c.ComicID,
                        c.Comic.Title,
                        c.Quantity,
                    });

                var result = comicsInventory.ToList();

                AddPaginationHeader(comicsInventory);

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

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPut("inventory/{comicID}")]
        [Authorize(Roles = "Admin")]
        public IActionResult PutComicInventory(int comicID, [FromBody] ComicInventoryDTO inventoryDTO)

        {
            try
            {
                svcComic.UpdateComicInventory(comicID, inventoryDTO.Quantity);
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
        [Authorize(Roles = "Admin")]
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
