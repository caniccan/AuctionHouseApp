using AuctionHouse.Core.Entities;
using AuctionHouse.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<WebAppContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Home/Login";
    options.LogoutPath= $"/Home/Logout";

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
