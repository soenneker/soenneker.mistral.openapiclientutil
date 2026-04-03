using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Mistral.HttpClients.Abstract;
using Soenneker.Mistral.OpenApiClientUtil.Abstract;
using Soenneker.Mistral.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Mistral.OpenApiClientUtil;

///<inheritdoc cref="IMistralOpenApiClientUtil"/>
public sealed class MistralOpenApiClientUtil : IMistralOpenApiClientUtil
{
    private readonly AsyncSingleton<MistralOpenApiClient> _client;

    public MistralOpenApiClientUtil(IMistralOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<MistralOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Mistral:ApiKey");
            string authHeaderValueTemplate = configuration["Mistral:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
