using ServiceStack.DataAnnotations;

namespace ReadingRoom.Data.Model
{
    /// <summary>
    /// Represents a reading room. Unique identifier,
    /// name, and seating capacity.
    /// </summary>
    public class Room
    {
        [AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
