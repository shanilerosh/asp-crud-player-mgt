using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;
using Player_mgt_system.Service;
using Player_mgt_system.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddScoped<ILoginService, LoginServiceImpl>();

builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlServer("server=DESKTOP-O2QVSJN\\SQLEXPRESS;Database=PlayerMgt;Trusted_Connection=True;MultipleActiveResultSets=True")
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<PlayerContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
