using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlServer("server=DESKTOP-O2QVSJN\\SQLEXPRESS;Database=PlayerMgt;Trusted_Connection=True;MultipleActiveResultSets=True")
);

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
