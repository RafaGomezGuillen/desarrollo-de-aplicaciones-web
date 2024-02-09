using Microsoft.EntityFrameworkCore;
using PO01_GomezRafael_v1.Data;

var builder = WebApplication.CreateBuilder(args);
// LA conexión....

builder.Services.AddDbContext<jardineriaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GomezContexto"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// La inicialización del seeder. El seedData está en jardineriaContext.cs

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