using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;

namespace ComicStore.Application.Filters
{
    public class AuthorFilter : BaseFilter<Author>
    {
        public int? AuthorID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public override Expression<Func<Author, bool>> GetPredicate()
        {
            Expression<Func<Author, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(Name))
                predicate = predicate.And(c => c.Name.Contains(Name));

            if (AuthorID.HasValue)
                predicate = predicate.And(c => c.AuthorID == AuthorID);

            if (Age.HasValue)
            {
                int yearOfBirth = DateTime.UtcNow.Year - Age.Value;
                predicate = predicate.And(c => c.BirthDate.Year == yearOfBirth);
            }

            return predicate;
        }
    }
}
