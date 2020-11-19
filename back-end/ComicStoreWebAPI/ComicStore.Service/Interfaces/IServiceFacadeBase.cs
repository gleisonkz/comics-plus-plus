namespace ComicStore.Service.Interfaces
{
    public interface IServiceFacadeBase
    {
        int Commit();
        void Rollback();
    }
}
