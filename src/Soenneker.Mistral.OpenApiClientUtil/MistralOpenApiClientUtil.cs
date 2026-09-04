using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Mistral.HttpClients.Abstract;
using Soenneker.Mistral.OpenApiClientUtil.Abstract;
using Soenneker.Mistral.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Mistral.OpenApiClientUtil;

/// <inheritdoc cref="IMistralOpenApiClientUtil" />
public sealed class MistralOpenApiClientUtil : IMistralOpenApiClientUtil
{
    private readonly AsyncSingleton<MistralOpenApiClient> _client;

    public MistralOpenApiClientUtil(IMistralOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<MistralOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new MistralOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<MistralOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
