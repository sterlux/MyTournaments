using Microsoft.OpenApi.Models;
using MyTournaments.Data;
using MyTournaments.Data.Context;
using MyTournaments.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog API", Version = "v1" });
});

builder.Services.Configure<TournamentDBSettings>(
    builder.Configuration.GetSection("TournamentDBSettings"));

builder.Services.AddScoped<ITournamentContext, TournamentContext>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tournaments API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
