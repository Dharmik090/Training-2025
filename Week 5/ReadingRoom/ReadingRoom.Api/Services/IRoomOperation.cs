using ReadingRoom.Data.Model;

namespace ReadingRoom.Api.Services
{
    public interface IRoomOperation : IDbOperation<Room>
    {
        List<Room> GetByCapacity(int capacity);
        List<Room> GetNBusiestRooms(int n, DateTime from, DateTime To);
    }
}
