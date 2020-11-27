using ComicStore.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComicStore.Service.Classes
{

    public class Paginator<TResult> : IEnumerable<TResult>, IPaginatorProperties
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        private IEnumerable<TResult> items;


        public Paginator(IEnumerable<TResult> items, int count, int pageIndex, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.items = items;
        }

        public IPaginatorProperties GetPaginatorMetadata()
        {
            return new MetaDataPaginatorAdapter(this);
        }

        public static Paginator<TResult> Paginate<TPoco>(IQueryable<TPoco> source, IFilter<TPoco> filter, Func<TPoco, TResult> projection)
        where TPoco : class
        {
            var predicate = filter.GetPredicate();
            source = source.Where(predicate);
            var count = source.Count();
            var items = source.Skip((filter.PageNumber - 1) * filter.PageSize)
                              .Take(filter.PageSize)
                              .Select(projection);
            return new Paginator<TResult>(items, count, filter.PageNumber, filter.PageSize);
        }
        public IEnumerator<TResult> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
