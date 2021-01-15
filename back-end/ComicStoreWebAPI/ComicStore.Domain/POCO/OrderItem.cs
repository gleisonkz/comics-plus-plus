using ComicStore.Domain.Helpers;
using ComicStore.Shared.Class;

namespace ComicStore.Domain.POCO
{
    public class OrderItem
    {
        private int quantity;
        private decimal unitValue;
        private decimal totalValue;
        public int OrderItemID { get; set; }
        public int ComicID { get; set; }
        public int OrderID { get; set; }
        public int Quantity
        {
            get => quantity;

            set
            {                
                quantity = ValidationHelper.SetValidation(value)
                                               .LessThanZero()
                                               .EqualsZero()
                                               .Assign();
            }
        }

        public decimal UnitValue
        {
            get { return unitValue; }
            set { unitValue = ValidationHelper.SetValidation(value)
                                               .LessThanZero()
                                               .EqualsZero()
                                               .Assign();
            }
        }

        public decimal TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = ValidationHelper.SetValidation(value)
                                             .LessThanZero()
                                             .EqualsZero()
                                             .Assign();
            }
        }
        public virtual Comic Comic { get; set; }
        public virtual Order Order { get; set; }
    }
}
