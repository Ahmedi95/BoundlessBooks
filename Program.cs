using Microsoft.EntityFrameworkCore;
using BoundlessBooks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// dependency injection
builder.Services.AddDbContext<BoundlessBooksDBContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));
builder.Services.AddScoped<BoundlessBooks.Services.RegisterService>();
builder.Services.AddScoped<BoundlessBooks.Services.LoginService>();

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
