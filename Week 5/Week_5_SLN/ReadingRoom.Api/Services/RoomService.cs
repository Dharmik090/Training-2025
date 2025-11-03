using ReadingRoom.Data.Model;
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
    }
}
