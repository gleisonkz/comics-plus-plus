using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;

namespace ComicStore.Application.Filters
{
    public class GenreFilter : BaseFilter<Genre>
    {
        public int? GenreID { get; set; }
        public string Description { get; set; }
        public override Expression<Func<Genre, bool>> GetPredicate()
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
