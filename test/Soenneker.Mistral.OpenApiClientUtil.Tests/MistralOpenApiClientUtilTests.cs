using Soenneker.Mistral.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Mistral.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MistralOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IMistralOpenApiClientUtil _openapiclientutil;

    public MistralOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IMistralOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
