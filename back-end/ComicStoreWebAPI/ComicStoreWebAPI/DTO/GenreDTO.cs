﻿using System.ComponentModel.DataAnnotations;
using ComicStore.Domain.Interfaces;

namespace ComicStore.Application.DTO
{
    public class GenreDTO : IGenreDTO
    {
        public int GenreID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
