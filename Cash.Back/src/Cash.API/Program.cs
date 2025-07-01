using Cash.API.Extensions;
using Cash.API.Middlewares;
using Cash.BE.Models;
using Cash.BL;
using Cash.DAC;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddDbContext<CashDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
