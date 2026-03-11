var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Lägg till tjänster i Dependency Injection-containern (Motorn)

builder.Services.AddControllers();

// Aktivera Swagger
builder.Services.AddEndpointsApiExplorer(); // Hjälper Swagger att hitta alla dina URL:er
builder.Services.AddSwaggerGen(); // Lägger till tjänsten som genererar Swagger-dokumentationen

var app = builder.Build();

// Configure the HTTP request pipeline.
// 2. Konfigurera Middleware-pipelinen (Där HTTP-requesten passerar)
if (app.Environment.IsDevelopment())
{
    // Aktivera Swagger i pipelinen
    app.UseSwagger(); // Genererar JSON-filen som beskriver ditt API
    app.UseSwaggerUI(); // Skapar det grafiska gränssnittet i webbläsaren
}

app.UseHttpsRedirection(); // Tvingar trafik över säker anslutning

app.UseAuthorization();

app.MapControllers(); // Talar om för appen att lyssna efter anrop till dina controllers

app.Run(); // Startar servern