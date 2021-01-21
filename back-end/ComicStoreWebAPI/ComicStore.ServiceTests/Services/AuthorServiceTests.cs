using ComicStore.Application.DTO;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Service.Services.Tests
{
    public class UnitOfWorkTest : IUnityOfWork
    {
        public int Commit()
        {
            return 1;
            //throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            //throw new System.NotImplementedException();
        }
    }
    public class FactoryRepositoryTest : IFactoryRepository
    {
        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new RepositoryTest<T>();
        }
    }
    public class RepositoryTest<T> : IRepository<T> where T : class 
    {
        private readonly static List<T> list = new List<T>();
        public T Add(T entity)
        {
            list.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Detach(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FindAsync(params object[] id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetQuery(bool trackingChanges = true)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
    [TestClass()]
    public class AuthorServiceTests
    {
        [TestMethod()]
        public void CreateAuthorTest()
        {
            var authorDTO = new AuthorDTO
            {
                AuthorID = 1,
                BirthDate = DateTime.UtcNow,
                Name = "Stan Lee",
                Nationality = "Mexican"
            };

            var factoryTest = new FactoryRepositoryTest();            
            var unityOfWorkTest = new UnitOfWorkTest();
            var authorService = new AuthorService(factoryTest, unityOfWorkTest);
            var author = authorService.CreateAuthor(authorDTO);
            authorService.Commit();
            
            Assert.AreEqual(authorDTO.AuthorID,author.AuthorID);
            Assert.AreEqual(authorDTO.BirthDate,author.BirthDate);
            Assert.AreEqual(authorDTO.Nationality,author.Nationality);
            Assert.AreEqual(authorDTO.Name,author.Name);
        }

        [TestMethod()]
        public void UpdateAuthorTest()
        {
            Assert.Fail();
        }
    }
}