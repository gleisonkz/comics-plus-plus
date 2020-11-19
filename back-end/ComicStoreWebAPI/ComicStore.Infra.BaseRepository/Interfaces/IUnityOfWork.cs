namespace ComicStore.Infra.BaseRepository.Interfaces
{
    public interface IUnityOfWork
    {
        int Commit();
        void Rollback();
    }
}
