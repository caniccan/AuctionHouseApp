using AuctionHouse.Order.Extensions;
using Microsoft.OpenApi.Models;
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

#region Swagger Dependencies

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order API", Version = "v1" });
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1"));
}

// Configure the HTTP request pipeline.

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
