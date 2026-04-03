using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Mistral.HttpClients.Registrars;
using Soenneker.Mistral.OpenApiClientUtil.Abstract;

namespace Soenneker.Mistral.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class MistralOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="MistralOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddMistralOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddMistralOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IMistralOpenApiClientUtil, MistralOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="MistralOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddMistralOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddMistralOpenApiHttpClientAsSingleton()
                .TryAddScoped<IMistralOpenApiClientUtil, MistralOpenApiClientUtil>();

        return services;
    }
}
