using Soenneker.Mistral.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Mistral.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Mistral OpenAPI client backed by the configured HTTP provider.
/// </summary>
public interface IMistralOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Mistral client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Mistral client.</returns>
    ValueTask<MistralOpenApiClient> Get(CancellationToken cancellationToken = default);
}
