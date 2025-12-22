namespace ReadingRoom.Data.Models
{
    /// <summary>
    /// Represents the current status of a room reservation.
    /// </summary>
    public enum Status
    {
        Pending = 0,
        Confirmed = 1,
        Completed = 2,
        Canceled = 3
    };
}
