using ReadingRoom.Data.Model;
using ReadingRoom.Data.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System.Data;

namespace ReadingRoom.Api.Services
{
    /// <summary>
    /// Provides database operations for Room entities.
    /// </summary>
    public class RoomService : IRoomOperation
    {
        private readonly IDbConnectionFactory _dbFactory;

        public RoomService(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
            using (IDbConnection db = _dbFactory.Open())
            {
                db.CreateTableIfNotExists<Reservation>();
            }
        }

        /// <summary>
        /// Retrieves a room by its ID.
        /// </summary>
        public Room GetById(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.SingleById<Room>(id);
            }
        }

        /// <summary>
        /// Retrieves all rooms from the database.
        /// </summary>
        public List<Room> GetAll()
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Select<Room>();
            }
        }

        /// <summary>
        /// Creates a new room record.
        /// </summary>
        public Room Create(Room room)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                db.Insert(room);
                room.Id = (int)db.LastInsertId();
                return room;
            }
        }

        /// <summary>
        /// Updates an existing room by ID.
        /// </summary>
        public bool Update(int id, Room room)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                room.Id = id;
                return db.Update(room) == 1;
            }
        }

        /// <summary>
        /// Deletes a room by its ID.
        /// </summary>
        public bool Delete(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.DeleteById<Room>(id) == 1;
            }
        }

        /// <summary>
        /// Get all rooms having capacity greater than or equal to the given value.
        /// can't be accessed via IDbOperation interface
        /// </summary>
        public List<Room> GetByCapacity(int capacity)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Select<Room>(r => r.Capacity >= capacity);
            }
        }

        /// <summary>
        /// Get N busiest rooms for given date range
        /// Busiest rooms means Reservation with status = complete
        /// </summary>
        public List<Room> GetNBusiestRooms(int n, DateTime from, DateTime to)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                List<Reservation> reservations = db.Select<Reservation>(r =>
                    r.Status == Status.Completed &&  // Only completed reservations
                    r.Start < to &&            // Reservation starts before 'to'
                    r.End > from               // Reservation ends after 'from' (overlaps)
                );

                var busiestRoomGroups = reservations
                    .GroupBy(r => r.RoomId)
                    .Select(g => new
                    {
                        RoomId = g.Key,
                        ReservationCount = g.Count()
                    })
                    .OrderByDescending(x => x.ReservationCount)
                    .Take(n)
                    .ToList();

                if (!busiestRoomGroups.Any())
                    return new List<Room>();

                List<int> roomIds = busiestRoomGroups.Select(x => x.RoomId).ToList();
                
                List<Room> rooms = db.Select<Room>(r => Sql.In(r.Id, roomIds));

                List<Room> orderedRooms = busiestRoomGroups
                    .Join(rooms,
                        rGroup => rGroup.RoomId,
                        room => room.Id,
                        (rGroup, room) => new { Room = room, rGroup.ReservationCount })
                    .OrderByDescending(x => x.ReservationCount)
                    .Select(x => x.Room)
                    .ToList();

                return orderedRooms;

            }
        }
    }
}

