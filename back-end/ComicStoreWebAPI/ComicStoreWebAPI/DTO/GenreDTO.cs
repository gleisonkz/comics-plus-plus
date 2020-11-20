using ComicStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Application.DTO
{
    public class GenreDTO : IGenreDTO
    {
        public int GenreID { get ; set ; }
        public string Description { get ; set ; }
    }
}
