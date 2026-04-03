using Soenneker.Mistral.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Mistral.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class MistralOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IMistralOpenApiClientUtil _openapiclientutil;

    public MistralOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IMistralOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
