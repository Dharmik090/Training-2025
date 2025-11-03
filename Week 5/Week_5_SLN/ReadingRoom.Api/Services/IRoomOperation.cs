using ReadingRoom.Data.Model;

namespace ReadingRoom.Api.Services
{
    public interface IRoomOperation : IDbOperation<Room>
    {
        List<Room> GetByCapacity(int capacity);
    }
}
