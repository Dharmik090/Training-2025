using ReadingRoom.Data.Model;

namespace ReadingRoom.Api.Services
{
    public interface IReservationOperaion : IDbOperation<Reservation>
    {
        List<Reservation> GetByRoomIdAndDate(int roomId, DateTime from, DateTime to);
        List<Reservation> GetConflicts();
    }
}
