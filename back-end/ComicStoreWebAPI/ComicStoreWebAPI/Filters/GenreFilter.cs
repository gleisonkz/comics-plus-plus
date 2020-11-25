using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;
using ComicStore.Service.Interfaces;

namespace ComicStore.Application.Filters
{
    public class GenreFilter : IFilter<Genre>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? GenreID { get; set; }
        public string Description { get; set; }
        public Expression<Func<Genre, bool>> GetPredicate()
        {
            Expression<Func<Genre, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(Description))
                predicate = predicate.And(c => c.Description.Contains(Description));

            if (GenreID.HasValue)
                predicate = predicate.And(c => c.GenreID == GenreID);
            return predicate;
        }
    }
}
