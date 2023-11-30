using System.Configuration;
using Microsoft.EntityFrameworkCore;
using WiFind.Data;
using WiFind.Services.Interfaces;
using WiFind.Services.WiFindServices;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
//Entity Framework congiguration
builder.Services.AddDbContext<WiFindDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WiFind Database"));
});

builder.Services.AddScoped<IWiFindUserService, WiFindUserService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IWifiService, WifiService>();
builder.Services.AddScoped<IWifiConnectionService, WifiConnectionService>();

var app = builder.Build();

//adds logging file
var path = Directory.GetCurrentDirectory();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

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

