namespace ComicStore.Service.Interfaces
{
    public interface IServiceFacade
    {
        int Commit();
        void Rollback();
    }
}
