using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuramos la inyeccion del DataContext
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

var app = builder.Build();

//Linea de comando para no tener problemas al consumir la appi desde el frond
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();