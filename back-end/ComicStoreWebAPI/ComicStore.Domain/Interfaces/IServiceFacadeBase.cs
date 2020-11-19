namespace ComicStore.Domain.Interfaces
{
    public interface IServiceFacade
    {
        int Commit();
        void Rollback();
    }
}
