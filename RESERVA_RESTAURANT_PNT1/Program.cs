using System.Configuration;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RESERVA_RESTAURANT_PNT1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<RestaurantContext>(options => options.UseInMemoryDatabase("RestaurantDB"));
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=ReservaResto-2022;Trusted_Connection=true;"));
// PC-KAIO\SQLEXPRESS

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.Run();
