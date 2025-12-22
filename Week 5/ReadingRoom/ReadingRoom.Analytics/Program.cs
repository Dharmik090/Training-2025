// See https://aka.ms/new-console-template for more information
using ReadingRoom.Data.Model;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System.Data;

Console.WriteLine("Hello, World!");

OrmLiteConnectionFactory _dbFactory = new OrmLiteConnectionFactory(
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReadingRoom;Integrated Security=True;",
    SqlServerOrmLiteDialectProvider.Instance
);

using (IDbConnection db = _dbFactory.Open())
{
    List<Room> rooms = db.Select<Room>();
    List<Reservation> reservations = db.Select<Reservation>();

    IEnumerable<Reservation> busiest = reservations
        .GroupBy(r => r.RoomId)
        .OrderByDescending(g => g.Count())
        .Take(3)
        .SelectMany(g => g);

    foreach (Reservation b in busiest)
        Console.WriteLine($"Room {b.RoomId}: {b.PatronName}");

}

Console.ReadLine();