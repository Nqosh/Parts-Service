using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PartsAPI.Core.Interfaces;
using PartsAPI.Infrastructure.Data;
using PartsAPI.Core.Profiles;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace PartsAPI.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
       IConfiguration config)
        {
            services.AddDbContext<PartContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            services.AddHealthChecks();
            //services.AddHealthChecks().AddNpgSql(config.GetConnectionString("DefaultConnection"));
            services.AddScoped<IPartRepository, PartRepository>();
            services.AddScoped<IHealthRepository, HealthRepository>();
            services.AddAutoMapper(typeof(PartProfile));
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

            return services;
        }
    }
}
