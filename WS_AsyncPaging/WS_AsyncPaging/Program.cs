using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WS_AsyncPaging.Exeptions;
using WS_AsyncPaging.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Lägg till tjänster i Dependency Injection-containern (Motorn)
builder.Services.AddControllers();

// Register CustomerService for DI
builder.Services.AddSingleton<ICustomerService, CustomerService>();

// Register ProductService for DI
builder.Services.AddSingleton<IProductService, ProductService>();

// Aktivera Swagger
builder.Services.AddEndpointsApiExplorer(); // Hjälper Swagger att hitta alla dina URL:er
//builder.Services.AddSwaggerGen(); // Lägger till tjänsten som genererar Swagger-dokumentationen
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Awesome API",
        Version = "v1"
    });

    // JWT Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT token like this: Bearer {your token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddProblemDetails(options => {
    // Här kan vi anpassa hur felet ska se ut globalt
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = context.HttpContext.Request.Path;
    };
});

//HybridCache är preview/experimental beroende på specifik .NET 9-version
#pragma warning disable EXTEXP0018 
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018

// Authentication-tjänsten
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// Authorization-tjänsten
builder.Services.AddAuthorization();

var app = builder.Build();

// Detta ska ligga HÖGST UPP i din middleware-pipeline (precis efter var app = builder.Build();) 
app.UseExceptionHandler(exceptionApp =>
{
    exceptionApp.Run(async context =>
    {
        // 1. Fånga felet som kastades
        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

        // 2. Mappa felet till rätt Statuskod och Titel
        var problemDetails = exception switch
        {
            NotFoundException ex => new Microsoft.AspNetCore.Mvc.ProblemDetails
            {
                Status = 404,
                Title = "Not Found",
                Detail = ex.Message
            },
            // Fånga alla andra (okända) fel
            _ => new Microsoft.AspNetCore.Mvc.ProblemDetails
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = "Ett oväntat fel inträffade. Försök igen senare."
            }
        };

        // 3. Sätt rätt statuskod på HTTP-svaret och skicka tillbaka JSON 
        context.Response.StatusCode = problemDetails.Status ?? 500;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

// Configure the HTTP request pipeline.
// 2. Konfigurera Middleware-pipelinen (Där HTTP-requesten passerar)
if (app.Environment.IsDevelopment())
{
    // Aktivera Swagger i pipelinen
    app.UseSwagger(); // Genererar JSON-filen som beskriver ditt API
    app.UseSwaggerUI(); // Skapar det grafiska gränssnittet i webbläsaren
}

// Tvingar trafik över säker anslutning
app.UseHttpsRedirection(); 

// Routing kartlägger vilken Controller som ska anropas
app.UseRouting();

// Authenticate: "Vem är du? Visa leg!"
app.UseAuthentication();

// Authorize: "Vad får du göra? Får du vara här?"
app.UseAuthorization();

// Talar om för appen att lyssna efter anrop till dina controllers
app.MapControllers();

// Startar servern
app.Run();