using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Infrastructure.Persistence;
using Publicacion.Infrastructure.Repository;

namespace Publicacion.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PublicationContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();

            return services;
        }
    }
}
