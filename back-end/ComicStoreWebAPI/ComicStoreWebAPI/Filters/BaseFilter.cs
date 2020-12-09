using System;
using System.Linq.Expressions;
using ComicStore.Service.Interfaces;

namespace ComicStore.Application.Filters
{
    public abstract class BaseFilter<T> : IFilter<T> where T : class
    {
        public virtual int PageNumber { get; set; } = 1;
        public virtual int PageSize { get; set; } = 10;
        public abstract Expression<Func<T, bool>> GetPredicate();
    }
}
