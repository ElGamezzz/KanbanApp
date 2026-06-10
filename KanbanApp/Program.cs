using KanbanApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Aquí van todas las configuraciones de servicios
builder.Services.AddDbContext<KanbanContext>(options =>
    options.UseSqlite("Data Source=kanban.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Después de configurar servicios, construyes la app
var app = builder.Build();

// 🔹 Middleware y configuración de la app
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
