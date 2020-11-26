using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;

namespace ComicStore.Application.Filters
{
    public class AuthorFilter : BaseFilter<Author>
    {
        public int? AuthorID { get; set; }
        public string Name { get; set; }
        public override Expression<Func<Author, bool>> GetPredicate()
        {
            Expression<Func<Author, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(Name))
                predicate = predicate.And(c => c.Name.Contains(Name));

            if (AuthorID.HasValue)
                predicate = predicate.And(c => c.AuthorID == AuthorID);
            return predicate;
        }
    }
}
