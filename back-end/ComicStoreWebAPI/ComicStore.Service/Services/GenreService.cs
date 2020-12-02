using System.Reflection.Metadata;
using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Linq;
using System.Collections.Generic;
using ComicStore.Service.Classes;
using System.Linq.Expressions;
using System;

namespace ComicStore.Service.Services
{
    public class GenreService : ServiceFacadeBase, IGenreService
    {

        public GenreService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {

        }

        public override int Commit()
        {
            int result = base.Commit();
            commands.ForEach(c => c.Execute());
            return result;
        }

        public Genre CreateGenre(IGenreDTO genreDTO)
        {
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            var objGenre = new Genre();
            genreDTO.AssignPoco(objGenre);

            commands.Add(new AssignGenreCommand(objGenre, genreDTO));
            repoGenre.Add(objGenre);
            return objGenre;
        }

        public Genre UpdateGenre(IGenreDTO genreDTO)
        {
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            Genre objGenre = repoGenre.GetQuery()
                                      .Where(c => c.GenreID == genreDTO.GenreID)
                                      .SingleOrDefault();
            genreDTO.AssignPoco(objGenre);
            repoGenre.Update(objGenre);
            return objGenre;
        }

        public Genre DeleteGenre(int genreID)
        {
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            Genre objGenre = repoGenre.GetQuery()
                                      .Where(c => c.GenreID == genreID)                                      
                                      .SingleOrDefault();
            if (objGenre.Comics.Any())
                throw new ApplicationException("Não é possível deletar uma categoria que possui vinculos");

            repoGenre.Delete(objGenre);
            return objGenre;
        }

        public IQueryable<Genre> GetGenre()
        {
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            return repoGenre.GetQuery();
        }

        public Paginator<IGenreDTO> GetGenres(IFilter<Genre> filter, Func<Genre, IGenreDTO> projection)
        {
            var repoGenre = factoryRepository.CreateRepository<Genre>();

            Expression<Func<Genre, bool>> predicate = filter.GetPredicate(); 

            return Paginator<IGenreDTO>
                .Paginate(repoGenre.GetQuery()
                                   .Where(predicate)
                                   .OrderBy(c => c.GenreID), filter, projection);
        }


    }
}
