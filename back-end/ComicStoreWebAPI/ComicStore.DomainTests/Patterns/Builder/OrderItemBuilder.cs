using ComicStore.Domain.POCO;

namespace ComicStore.DomainTests.Patterns.Builder
{
    public class OrderItemBuilder :
        TestBuilder<OrderItemBuilder, OrderItem>
    {
        public OrderItemBuilder WithQuantity(int quantity)
        {
            Subject.Quantity = quantity;
            return this;
        }

        public OrderItemBuilder WithUnitValue(decimal value)
        {
            Subject.UnitValue = value;
            return this;
        }

        public OrderItemBuilder WithTotalValue(decimal value)
        {
            Subject.TotalValue = value;
            return this;
        }
    }
}
