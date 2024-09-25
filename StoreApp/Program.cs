using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext();
builder.Services.ConfigureSession();

builder.Services.ConfigureRepoReg();
builder.Services.ConfigureServiceReg();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();