using Kanban.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar Base de Datos (Lo que hicimos en la Fase 1)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configurar Controladores y Swagger (¡Esto es lo que probablemente faltaba!)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Habilitar Swagger en modo Desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto habilita la página web de Swagger
}

app.UseAuthorization();
app.MapControllers(); // Esto le dice a la API que use los controladores (TasksController)

app.Run();