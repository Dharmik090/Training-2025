namespace ReadingRoom.Api.Services
{
    public interface IDbOperation<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T item);
        bool Update(int id, T item);
        bool Delete(int id);
    }
}
