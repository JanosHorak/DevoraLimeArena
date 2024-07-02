using DevoraLimeArena.DB;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.DB.Repository;
using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ArenaDBContext>(options => options.UseInMemoryDatabase("DLArena"));

builder.Services.AddScoped<IArenaRepository, ArenaRepository>();
builder.Services.AddScoped<IFighterRepository, FighterRepository>();
builder.Services.AddScoped<IArenaHistoryRepository, ArenaHistoryRepository>();
builder.Services.AddScoped<IArenaservice,ArenaService>();
builder.Services.AddScoped<IBarracksService,BarracksService>();
builder.Services.AddScoped<IFighterFactory,FighterFactory>();
builder.Services.AddScoped<IRandomRoller,RandomRoller>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
