using Microsoft.EntityFrameworkCore;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cnnString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); // Se inyecta el repositorio
//al controller como un servidor del Contendedor de dependencias.

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
