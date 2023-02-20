using AuctionHouse.Order.Extensions;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
