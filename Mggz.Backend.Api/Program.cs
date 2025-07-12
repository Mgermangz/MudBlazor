using Mggz.AccessData.ContextDB;
using Mggz.Shared.Entidades.Admin;
using Mggz.Shared.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DelabDbContext>(conexion => 
                              conexion.UseSqlServer("name=DelabConexionString", options => options.MigrationsAssembly("Mggz.AccessData")));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders Backend", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});
// Sistema de Autenticación y Autorización con el Usuario personalizado
builder.Services.AddIdentity<Usuario, IdentityRole>(cfg =>
                {   // Validar Confirmación de Correo Electrónico
                    cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                    cfg.User.RequireUniqueEmail = true;
                    // Configuración de Contraseña
                    cfg.Password.RequiredLength = 6;
                    cfg.Password.RequireDigit = false;
                    cfg.Password.RequireLowercase = false;
                    cfg.Password.RequireUppercase = false;
                    cfg.Password.RequireNonAlphanumeric = false;
                    // Configuración de Bloqueo de Cuenta
                    cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    cfg.Lockout.MaxFailedAccessAttempts = 5;
                    cfg.Lockout.AllowedForNewUsers = true;
                })
                .AddEntityFrameworkStores<DelabDbContext>()
                .AddDefaultTokenProviders();
// Configuración de la Autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),
                        ClockSkew = TimeSpan.Zero, // Reduce el tiempo de espera para la expiración del token
                    };
                });
// Librerias Terceros
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    string swaggerUrl = "https://localhost:7229/swagger"; // URL de Swagger
    await Task.Run(() => OpenBrowser(swaggerUrl));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Método para abrir el navegador
static void OpenBrowser(string url)
{
    try
    {
        var psi = new System.Diagnostics.ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        };
        System.Diagnostics.Process.Start(psi);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al abrir el navegador: {ex.Message}");
    }
}
