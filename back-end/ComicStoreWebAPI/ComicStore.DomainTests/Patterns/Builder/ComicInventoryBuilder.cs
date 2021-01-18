using ComicStore.Domain.POCO;

namespace ComicStore.DomainTests.Patterns.Builder
{
    public class ComicInventoryBuilder
        : TestBuilder<ComicInventoryBuilder, ComicInventory>
    {
        public ComicInventoryBuilder WithQuantity(int quantity)
        {
            Subject.Quantity = quantity;
            return this;
        }
    }
}
