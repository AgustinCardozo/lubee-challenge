using Microsoft.Extensions.DependencyInjection;
using Publicacion.Application.Contracts.UseCases;
using Publicacion.Application.UseCases.Publications;

namespace Publicacion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPublicationUseCase, PublicationUseCase>();

        return services;
    }
}
