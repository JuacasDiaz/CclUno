using System.Text;
using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using CclInventoryApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Startup;

var builder = WebApplication.CreateBuilder(args);

// CONFIGURAR SERVICIOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTRAR REPOSITORIOS Y SERVICIOS
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInventoryEntryRepository, InventoryEntryRepository>();
builder.Services.AddScoped<IInventoryEntryService, InventoryEntryService>();
builder.Services.AddScoped<IInventoryExitRepository, InventoryExitRepository>();
builder.Services.AddScoped<IInventoryExitService, InventoryExitService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockHistoryRepository, StockHistoryRepository>();
builder.Services.AddScoped<IStockHistoryService, StockHistoryService>();

// REGISTRAR EL SERVICIO SINGLETON
builder.Services.AddSingleton<SingletonService>();

// CONFIGURAR AUTENTICACIÓN JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "YourIssuerHere", // Reemplaza con tu emisor
                ValidAudience = "YourAudienceHere", // Reemplaza con tu audiencia
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")) // Reemplaza con tu clave secreta
            };
        });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

// CONFIGURAR EL MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
