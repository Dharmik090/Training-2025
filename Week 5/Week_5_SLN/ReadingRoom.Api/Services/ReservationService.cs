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
                db.Insert(res);
                res.Id = (int)db.LastInsertId();
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
    }
}
