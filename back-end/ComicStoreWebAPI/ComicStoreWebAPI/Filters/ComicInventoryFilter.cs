using ComicStore.Domain.POCO;
using System;
using System.Linq.Expressions;

namespace ComicStore.Application.Filters
{
    public class ComicInventoryFilter : BaseFilter<ComicInventory>
    {
        public int? ComicID { get; set; }
        public string Title { get; set; }
        public int? Quantity { get; set; }
        public override Expression<Func<ComicInventory, bool>> GetPredicate()
        {
            Expression<Func<ComicInventory, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(Title))
                predicate = predicate.And(c => c.Comic.Title.Contains(Title));

            if (Quantity.HasValue)
                predicate = predicate.And(c => c.Quantity == Quantity);

            if (ComicID.HasValue)
                predicate = predicate.And(c => c.ComicID == ComicID);

            return predicate;
        }
    }
}
