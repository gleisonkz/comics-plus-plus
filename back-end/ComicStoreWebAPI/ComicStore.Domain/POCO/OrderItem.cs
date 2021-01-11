using ComicStore.Shared.Class;

namespace ComicStore.Domain.POCO
{
    public class OrderItem
    {
        private int quantity;
        public int OrderItemID { get; set; }
        public int ComicID { get; set; }
        public int OrderID { get; set; }
        public int Quantity
        {
            get => quantity;

            set
            {
                if (value <= 0)
                    throw new CustomException("A quantidade não pode ser menor ou igual a 0");
                quantity = value;
            }
        }
        public float UnitValue { get; set; }
        public float TotalValue { get; set; }
        public virtual Comic Comic { get; set; }
        public virtual Order Order { get; set; }
    }
}
