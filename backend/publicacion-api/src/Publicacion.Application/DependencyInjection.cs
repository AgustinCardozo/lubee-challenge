using Microsoft.Extensions.DependencyInjection;
using Publicacion.Application.Contracts.UseCases;
using Publicacion.Application.Contracts.UseCases.Images;
using Publicacion.Application.UseCases.Images;
using Publicacion.Application.UseCases.Publications;

namespace Publicacion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IImageUseCase, ImageUseCase>();
        services.AddScoped<IPublicationUseCase, PublicationUseCase>();

        return services;
    }
}
