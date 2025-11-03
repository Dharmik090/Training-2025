using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Data.Model;
using ReadingRoom.Api.Services;

namespace ReadingRoom.Api.Controllers
{
    /// <summary>
    /// Handles reservation-related API requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        // No Dependency Injection, for simplicity, we instantiate the service directly
        // Tight coupling - not recommended for production code
        //private readonly ReservationService _service = new();

        // Using Depedency Injection
        // Still can't use methods other than those defined in the IDbOperation<Room> interface
        //private readonly IDbOperation<Reservation> _service;

        // Using Depedecy Injection
        // Can use all methods of ReservationService class, also those not defined in the IDbOperation<Reservation> interface
        private readonly IReservationOperaion _service;

        public ReservationController(IReservationOperaion service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all reservations.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _service.GetAll();
            return Ok(reservations);
        }

        /// <summary>
        /// Retrieves a reservation by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _service.GetById(id);
            return reservation != null ? Ok(reservation) : NotFound();
        }

        /// <summary>
        /// Creates a new reservation.
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] Reservation res)
        {
            if (res == null)
                return BadRequest("Reservation data is required.");

            var created = _service.Create(res);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing reservation by ID.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Reservation res)
        {
            if (res == null)
                return BadRequest("Reservation data is required.");

            var updated = _service.Update(id, res);
            return updated ? Ok(res) : NotFound();
        }

        /// <summary>
        /// Deletes a reservation by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
