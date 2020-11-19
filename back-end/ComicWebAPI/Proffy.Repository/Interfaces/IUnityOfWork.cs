namespace Proffy.Repository.Interfaces
{
    public interface IUnityOfWork
    {
        int Commit();
        void Rollback();
    }
}
