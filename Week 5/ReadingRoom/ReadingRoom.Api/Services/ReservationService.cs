using ReadingRoom.Data.Model;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System.Data;

namespace ReadingRoom.Api.Services
{
    /// <summary>
    /// Provides database operations for Reservation entities.
    /// </summary>
    public class ReservationService : IReservationOperaion
    {
        private readonly IDbConnectionFactory _dbFactory;

        public ReservationService(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
            using (IDbConnection db = _dbFactory.Open())
            {
                db.CreateTableIfNotExists<Reservation>();
            }
        }

        /// <summary>
        /// Retrieves a reservation by its ID.
        /// </summary>
        public Reservation GetById(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.SingleById<Reservation>(id);
            }
        }

        /// <summary>
        /// Retrieves all reservations from the database.
        /// </summary>
        public List<Reservation> GetAll()
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Select<Reservation>();
            }
        }

        /// <summary>
        /// Creates a new reservation record.
        /// </summary>
        public Reservation Create(Reservation res)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                res.Id = (int)db.Insert(res, selectIdentity: true);
                return res;
            }
        }

        /// <summary>
        /// Updates an existing reservation by ID.
        /// </summary>
        public bool Update(int id, Reservation res)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                res.Id = id;
                return db.Update(res) == 1;
            }
        }

        /// <summary>
        /// Deletes a reservation by its ID.
        /// </summary>
        public bool Delete(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.DeleteById<Reservation>(id) == 1;
            }
        }

        /// <summary>
        /// Get by room id & starting and ending date
        /// </summary>
        public List<Reservation> GetByRoomIdAndDate(int roomId, DateTime from, DateTime to)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Select<Reservation>(r => r.RoomId == roomId && r.Start >= from && r.End <= to);
            }
        }

        /// <summary>
        /// Returns reservations with conflicts based on overlapping time.
        /// </summary>
        public List<Reservation> GetConflicts()
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                List<Reservation> allReservations = db.Select<Reservation>();

                List<Reservation> conflicts = allReservations
                    .SelectMany(a => allReservations, (a, b) => new { a, b })   // a, b : a row of Reservation table
                    .Where(x => x.a.RoomId == x.b.RoomId &&     // get matching rows with same room id
                                x.a.Id != x.b.Id &&     // remove same reservation
                                x.a.Start < x.b.End &&      // 2 condition for overlapping reservation
                                x.a.End > x.b.Start)
                    .Select(x => x.a)
                    .ToList();

                return conflicts;
            }

        }
    }
}
