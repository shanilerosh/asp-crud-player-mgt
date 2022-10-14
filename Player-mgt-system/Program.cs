using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;
using Player_mgt_system.Service;
using Player_mgt_system.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();


builder.Services.AddScoped<ILoginService, LoginServiceImpl>();

builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=PlayerMgt1;Trusted_Connection=True;MultipleActiveResultSets=True")
);

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();