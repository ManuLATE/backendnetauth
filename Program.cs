using Microsoft.EntityFrameworkCore;
using backendnet.Data;
using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backendnet.Middlewares;
using backendnet.Services;
var builder = WebApplication.CreateBuilder(args);
// Soporte para generar JWT
builder.Services.AddScoped<JwtTokenService>();
// Agrega el soporte para MySQL
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<IdentityContext>(options =>
{
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Soporte para Identity
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(options =>
{
options.User.RequireUniqueEmail = true;
// Cambie aqui como quiere se manejen sus contraseñas
options.Password.RequireDigit = false;
options.Password.RequireLowercase = false;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequireUppercase = false;
options.Password.RequiredLength = 6;
options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<IdentityContext>();
// Soporte para JWT
builder.Services
.AddHttpContextAccessor() // Para poder acceder al HttpContext()
.AddAuthorization() // Para autorizar en cada método el acceso
.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => // Para autenticar con JWT
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
ValidIssuer = builder.Configuration["Jwt:Issuer"], // Leido desde appSettings
ValidAudience = builder.Configuration["Jwt:Audience"], // Leido desde appSettings
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
};
});
// Agrega el soporte para CORS
builder.Services.AddCors(options =>
{
options.AddDefaultPolicy(
policy =>
{
policy.WithOrigins("http://localhost:3001", "http://localhost:8080")
.AllowAnyHeader()
.WithMethods("GET", "POST", "PUT", "DELETE");
});
});
// Agrega la funcionalidad de controladores
builder.Services.AddControllers();
// Agrega la documentación de la API
builder.Services.AddSwaggerGen();
// Construye la aplicación web
var app = builder.Build();

// Mostraremos la documentación solo en ambiente de desarrollo
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}
// Agregamos un middleware para el manejo de errores
app.UseExceptionHandler("/error");
// Utiliza rutas para los endpoints de los controladores
app.UseRouting();
// Utiliza Autenticacion
app.UseAuthentication();
// Utiliza Autorizacion
app.UseAuthorization();
// Agrega el middleware para refrescar el token
app.UseSlidingExpirationJwt();
// Usa Cors con la policy definida anteriormente
app.UseCors();
// Establece el uso de rutas sin especificar una por default
app.MapControllers();
app.Run();
