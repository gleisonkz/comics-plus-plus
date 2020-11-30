using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;

namespace ComicStore.Application.Filters
{
    public class ComicFilter : BaseFilter<Comic>
    {
        public int? ComicID { get; set; } = null;
        public string Title { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public int? Year { get; set; }
        public int? Pages { get; set; }
        public int[] Authors { get; set; }
        public int[] Genres { get; set; }
        public byte[] Image { get; set; }
        public override Expression<Func<Comic, bool>> GetPredicate()
        {
            Expression<Func<Comic, bool>> predicate = c => true;

            if (ComicID.HasValue)
                predicate = predicate.And(c => c.ComicID == ComicID);

            if (!string.IsNullOrEmpty(Title))
                predicate = predicate.And(c => c.Title.Contains(Title));

            if (!string.IsNullOrEmpty(Description))
                predicate = predicate.And(c => c.Description.Contains(Description));

            if (Price.HasValue)
                predicate = predicate.And(c => c.Price == Price);

            if (Year.HasValue)
                predicate = predicate.And(c => c.Year == Year);

            if (Pages.HasValue)
                predicate = predicate.And(c => c.Pages == Pages);

            //if (Authors.Length > 0)
            //    predicate = predicate.And(c => c.Authors;

            //if (Genres.Length > 0)
            //    predicate = predicate.And(c => c.Genres;

            return predicate;
        }
    }
}
