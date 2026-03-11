using WS_AsyncPaging.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Lägg till tjänster i Dependency Injection-containern (Motorn)

builder.Services.AddControllers();

// Register CustomerService for DI
builder.Services.AddSingleton<ICustomerService, CustomerService>();

// Register ProductService for DI
builder.Services.AddSingleton<IProductService, ProductService>();

// Aktivera Swagger
builder.Services.AddEndpointsApiExplorer(); // Hjälper Swagger att hitta alla dina URL:er
builder.Services.AddSwaggerGen(); // Lägger till tjänsten som genererar Swagger-dokumentationen

builder.Services.AddProblemDetails();

#pragma warning disable EXTEXP0018 //HybridCache är preview/experimental beroende på specifik .NET 9-version
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018

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