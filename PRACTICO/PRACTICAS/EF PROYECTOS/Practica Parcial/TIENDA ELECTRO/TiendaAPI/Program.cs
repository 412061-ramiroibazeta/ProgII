using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TiendaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

//--1) Todos los productos
//--2) Todos los productos entre precios a y b
//--3) Producto por nombre
//--4) Producto por categor�a 
//--5) Productos que hayan ingresado a partir de una fecha
//--6) Al ingresar un producto se debe validar que todos los datos est�n correctos y la fecha de ingreso al d�a que se hizo la operaci�n.
//--7) Al actualizar el stock, se debe actualizar la fecha de ingreso al d�a que se hizo la operaci�n.