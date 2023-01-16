
using BusinessLayer;
using BusinessLayer.Interface;
using Data;
using Data.Interface;
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<MvcPruebasContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));
builder.Services.AddScoped<IBaleroDA, BalerosDA>();
builder.Services.AddScoped<IBaleroBC, BaleroBC>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
