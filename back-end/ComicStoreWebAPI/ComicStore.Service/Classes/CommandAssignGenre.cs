﻿using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Interfaces;

namespace ComicStore.Service.Classes
{
    public class CommandAssignGenre : ICommand
    {
        private readonly Genre genre;
        private readonly IGenreDTO genreDTO;

        public CommandAssignGenre(Genre genre, IGenreDTO genreDTO)
        {
            this.genre = genre;
            this.genreDTO = genreDTO;
        }

        public void Execute()
        {
            genreDTO.GenreID = genre.GenreID;
        }
    }
}
