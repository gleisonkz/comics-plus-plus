using ComicStore.Shared.Class;

namespace ComicStore.Domain.POCO
{
    public class ComicInventory
    {
        private int quantity;
        public int ComicID { get; set; }
        public int Quantity
        {
            get => quantity;

            set
            {
                if (value < 0)
                    throw new CustomException("A quantidade não pode ser menor ou igual a 0");
                quantity = value;
            }
        }
        public virtual Comic Comic { get; set; }

        public void QuantityDown(int quantityDown)
        {

            if (quantityDown <= 0)
            {
                throw new CustomException("A quantidade deve ser maior do que 0");
            }


            if (Quantity < quantityDown)
            {
                throw new CustomException("Não há itens disponíveis");
            }

            Quantity -= quantityDown;
        }
    }
}
