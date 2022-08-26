using Microsoft.EntityFrameworkCore;
using PRUEBA.BACKEND.APPLICATION.AppServices;
using PRUEBA.BACKEND.APPLICATION.Interfaces;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using PRUEBA.BACKEND.INFRA.REPOSITORY.Model;
using PRUEBA.BACKEND.INFRA.REPOSITORY.Services;

namespace PRUEBA.BACKEND.API.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            #region inyeccion_dependencias
            services.AddDbContext<DBContexto>(options => options.UseSqlServer(configuration["DBString"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientesAppService, ClientesAppService>();
            services.AddScoped<ICuentasAppService, CuentasAppService>();
            services.AddScoped<IMovimientosAppService, MovimientosAppService>();
            #endregion

            #region servicios_aplicativo
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(policy =>
            {
                policy.AddPolicy("AllowAll", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
            #endregion

            return services;
        }
        public static WebApplication UseServices(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowAll");

            return app;
        }
    }
}
