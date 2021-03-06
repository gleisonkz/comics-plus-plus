﻿using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Service.Interfaces;

namespace ComicStore.Infra.EFRepository.Repository
{
    public class FactoryEFCoreRepository : IFactoryRepository
    {
        private readonly ComicStoreDbContext context;

        public FactoryEFCoreRepository(ComicStoreDbContext context)
        {
            this.context = context;
        }
        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new EFCoreRepository<T>(context);
        }
    }
}
