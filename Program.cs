using Microsoft.EntityFrameworkCore;
using BoundlessBooks.Data;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Redis cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "books-data-tti7zt.serverless.use1.cache.amazonaws.com:6379,abortConnect=false"; 
    options.InstanceName = "AllBooksCache";
    options.Configuration = "localhost:6379";
});


// dependency injection
builder.Services.AddDbContext<BoundlessBooksDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version()))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

// registering services for the DI
builder.Services.AddScoped<BoundlessBooks.Services.RegisterService>();
builder.Services.AddScoped<BoundlessBooks.Services.LoginService>();
builder.Services.AddScoped<BoundlessBooks.Services.HomeService>();
builder.Services.AddScoped<BoundlessBooks.Services.CartService>();
builder.Services.AddScoped<BoundlessBooks.Services.CheckoutService>();
builder.Services.AddScoped<BoundlessBooks.Services.UserService>();


builder.Services.AddControllersWithViews();

// configuring session state
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// using session state
app.UseSession();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "assets")),
    RequestPath = "/assets"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
