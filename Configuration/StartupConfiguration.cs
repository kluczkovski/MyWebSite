using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;
using MyWebSite.Repository;
using MyWebSite.Repository.Interface;

namespace MyWebSite.Configuration
{
    public static class StartupConfiguration
    {
        public static IServiceCollection SetupDBContext (this IServiceCollection services, IConfiguration configuration)
        {
            // Setup App Context - System Tables
            services.AddDbContext<MyDBContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), builder =>
                builder.MigrationsAssembly("MyWebSite")));

            return services;
        }

        public static IServiceCollection DIConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectImageRepository, ProjectImageRepository>();
            return services;
        }

    }
}
