using System;
using System.Linq.Expressions;

namespace ComicStore.Service.Interfaces
{
    public interface IFilter<T> where T : class
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        Expression<Func<T, bool>> GetPredicate();

    }
}