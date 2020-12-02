﻿using ComicStore.Application.DTO;
using ComicStore.Application.Filters;
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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService svcGenre;

        public GenreController(IGenreService svcGenre)
        {
            this.svcGenre = svcGenre;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetGenre([FromQuery] GenreFilter filter)
        {
            var genres = svcGenre.GetGenres(
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

            return Ok(genres);
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
        public IActionResult PutGenre(int genreID,[FromBody] GenreDTO genreDTO)
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
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                svcGenre.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
