using Soenneker.Mistral.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Mistral.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IMistralOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<MistralOpenApiClient> Get(CancellationToken cancellationToken = default);
}
