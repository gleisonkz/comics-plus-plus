using ComicStore.Domain.POCO;

namespace ComicStore.DomainTests.Patterns.Builder
{
    public class ComicBuilder
        : TestBuilder<ComicBuilder, Comic>
    {
        public ComicBuilder WithPages(int numberPages)
        {
            Subject.Pages = numberPages;
            return this;
        }

        public ComicBuilder WithPrice(decimal price)
        {
            Subject.Price = price;
            return this;            
        }



        public ComicBuilder WithYear(int year)
        {
            Subject.Year = year;
            return this;
        }
    }
}
