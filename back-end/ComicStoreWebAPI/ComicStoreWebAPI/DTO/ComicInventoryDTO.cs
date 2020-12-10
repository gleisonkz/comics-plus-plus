using ComicStore.Domain.POCO;
using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{
    public class ComicInventoryDTO
    {
        public int ComicID { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }
        public void AssignPocoFromDTO(ComicInventory poco)
        {
            poco.ComicID = ComicID;
            poco.Quantity = Quantity;
        }

        public void AssignDtoFromPoco(ComicInventory poco)
        {
            ComicID = poco.ComicID;
            Quantity = poco.Quantity;
            Title = poco.Comic.Title;
        }
    }
}
