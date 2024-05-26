using System.Text;
using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using CclInventoryApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // MÉTODO PARA CONFIGURAR LOS SERVICIOS
    public void ConfigureServices(IServiceCollection services)
    {
        // CONFIGURAR EL CONTEXTO DE LA BASE DE DATOS
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        // REGISTRAR REPOSITORIOS Y SERVICIOS
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IInventoryEntryRepository, InventoryEntryRepository>();
        services.AddScoped<IInventoryEntryService, InventoryEntryService>();
        services.AddScoped<IInventoryExitRepository, InventoryExitRepository>();
        services.AddScoped<IInventoryExitService, InventoryExitService>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IStockHistoryRepository, StockHistoryRepository>();
        services.AddScoped<IStockHistoryService, StockHistoryService>();

        // REGISTRAR EL SERVICIO SINGLETON
        services.AddSingleton<SingletonService>();

        // CONFIGURAR AUTENTICACIÓN JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
        services.AddAuthorization();

        services.AddControllers();
    }

    // MÉTODO PARA CONFIGURAR EL PIPELINE DE LA APLICACIÓN
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    internal class SingletonService
    {
    }
}
