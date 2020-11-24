using ComicStore.Service.Interfaces;

namespace ComicStore.Service.Classes
{
    public class MetaDataPaginatorAdapter : IPaginatorProperties
    {
        private readonly IPaginatorProperties properties;

        public MetaDataPaginatorAdapter(IPaginatorProperties properties)
        {
            this.properties = properties;
        }
        public int CurrentPage => properties.CurrentPage;

        public int TotalPages => properties.TotalPages;

        public int PageSize => properties.PageSize;

        public int TotalCount => properties.TotalCount;

        public bool HasPrevious => properties.HasPrevious;

        public bool HasNext => properties.HasNext;
    }

}
