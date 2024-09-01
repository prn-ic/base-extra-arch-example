using BaseCoreExample.Core.Repositories;
using BaseCoreExample.Persistanse.Data;
using BaseCoreExample.Persistanse.Options;
using BaseCoreExample.Persistanse.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BaseCoreExample.Persistanse
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNpgsqlEntityFrameworkPersistanse(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseNpgsql(configuration.GetConnectionString("Postgre"));
            });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection ConfigurePersistanseOptions(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<DbConnectionOption>(o =>
                configuration.GetSection("DbConnectionOption")
            );
            return services;
        }
    }
}
