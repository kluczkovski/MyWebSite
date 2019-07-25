using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;

namespace MyWebSite.Configuration
{
    public static class ConfigurationDBContext
    {
        public static IServiceCollection SetupDBContext (this IServiceCollection services, IConfiguration configuration)
        {
            // Setup App Context - System Tables
            services.AddDbContext<MyDBContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), builder =>
                builder.MigrationsAssembly("MyWebSite")));

            return services;
        }
    }
}
