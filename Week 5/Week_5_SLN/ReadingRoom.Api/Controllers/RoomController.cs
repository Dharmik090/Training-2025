using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Api.Services;
using ReadingRoom.Data.Model;

namespace ReadingRoom.Api.Controllers
{
    /// <summary>
    /// Handles CRUD operations for rooms.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        // No Dependency Injection, for simplicity, we instantiate the service directly
        // Tight coupling - not recommended for production code
        //private readonly RoomService _service = new();

        // Using Dependecy Injection
        // Still can't use methods other than those defined in the IDbOperation<Room> interface
        //private readonly IDbOperation<Room> _service;

        // Using Depedecy Injection
        // Can use all methods of RoomService class, also those not defined in the IDbOperation<Room> interface
        private readonly IRoomOperation _service;

        public RoomController(IRoomOperation service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves a room by its ID.
        /// </summary>
        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        /// <summary>
        /// Retrieves all rooms.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        /// <summary>
        /// Creates a new room.
        /// </summary>
        [HttpPost]
        public IActionResult Create(Room room) => Ok(_service.Create(room));

        /// <summary>
        /// Updates an existing room by ID.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Room room)
        {
            return _service.Update(id, room) ? Ok(room) : NotFound();
        }

        /// <summary>
        /// Deletes a room by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }

        /// <summary>
        /// Get rooms having capacity greater than or equal to the specified value.
        /// </summary>
        [HttpGet("capacity/{capactiy}")]
        public IActionResult GetByCapactiy(int capactiy)
        {
            return Ok(_service.GetByCapacity(capactiy));
        }
    }
}
