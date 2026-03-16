using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test.Subscriber.Core.Interfaces;
using Test.Subscriber.Infraestructure.Database;
using Test.Subscriber.Infraestructure.Database.Repositories;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Test.Subscriber.Infraestructure.Extensions
{
    public static class SubscriberInfrastructureExtension
    {
        public static IServiceCollection AddSubscriberInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<SubscriberDbContext>(options => options
                .UseNpgsql(connectionString, config =>
                {
                    config.MigrationsHistoryTable("__EFMigrationsHistory", "public");
                    config.MigrationsAssembly(typeof(SubscriberDbContext).Assembly.GetName().Name);
                })
                .UseSnakeCaseNamingConvention()
            );

            services.AddScoped<ISubscriberRepository, SubscriberRepository>();

            return services;

        }

        public static IApplicationBuilder AddSubscriberInfrastructure(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<SubscriberDbContext>();

            context.Database.Migrate();

            return app;
        }
    }
}
