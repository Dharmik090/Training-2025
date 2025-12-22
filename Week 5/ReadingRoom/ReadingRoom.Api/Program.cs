using Microsoft.EntityFrameworkCore;
using ReadingRoom.Api.Services;
using ReadingRoom.Data.Model;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IDbConnectionFactory>(con =>
    new OrmLiteConnectionFactory(
        builder.Configuration.GetConnectionString("DefaultString"),
        SqlServerOrmLiteDialectProvider.Instance
    )
);

builder.Services.AddScoped<IRoomOperation, RoomService>();
builder.Services.AddScoped<IReservationOperaion, ReservationService>();


var app = builder.Build();

app.MapControllers();

app.Run();


