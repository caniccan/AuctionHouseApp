using AuctionHouse.Sourcing.Data;
using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Repositories;
using AuctionHouse.Sourcing.Repositories.Interfaces;
using AuctionHouse.Sourcing.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Configuration Dependencies
builder.Services.Configure<SourcingDatabaseSettings>(builder.Configuration.GetSection(nameof(SourcingDatabaseSettings)));
builder.Services.AddSingleton<ISourcingDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SourcingDatabaseSettings>>().Value);
#endregion

#region Project Dependencies
builder.Services.AddTransient<ISourcingContext, SourcingContext>();
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IBidRepository, BidRepository>();
#endregion

#region Swagger Dependencies
builder.Services.AddSwaggerGen(x =>
{

    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AuctionHouse.Sourcing",
        Version = "v1"
    });
});
#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sourcing API V1"));
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
