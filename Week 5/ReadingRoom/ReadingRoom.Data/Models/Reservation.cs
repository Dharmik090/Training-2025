using ReadingRoom.Data.Models;
using ServiceStack.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReadingRoom.Data.Model
{
    /// <summary>
    /// Represents a reservation made by a patron for a specific reading room within the library.
    /// </summary>
    public class Reservation
    {
        [AutoIncrement]
        public int Id { get; set; }
        [References(typeof(Room))]
        public int RoomId { get; set; }
        [Required]
        public string PatronName { get; set; } = string.Empty;
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }
    }
}
