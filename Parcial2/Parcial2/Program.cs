using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");


builder.Services.AddDbContext<BDProyectoContext>(options => options.UseSqlServer(connectionString));

//Definimos la nueva politica Cross-Origin REsource Sharing (CORS o Uso compartido de recursos entre origenes)
//para que la API sea accesible para culaquier aplicacion
builder.Services.AddCors(options => {

    options.AddPolicy("NuevaPolitica", app =>
    {

        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });

});


builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
