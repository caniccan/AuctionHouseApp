using AuctionHouse.Order.Extensions;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Add Infrastructure

builder.Services.AddInfrastructure(builder.Configuration);

#endregion

#region Add Application

builder.Services.AddApplication();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
