[![](https://img.shields.io/nuget/v/soenneker.mistral.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.mistral.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.mistral.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.mistral.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.mistral.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.mistral.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.mistral.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.mistral.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Mistral.OpenApiClientUtil

Provides a configured Mistral API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Mistral.OpenApiClientUtil
```

## Configuration

```json
{
  "Mistral": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Mistral.OpenApiClientUtil.Abstract;
using Soenneker.Mistral.OpenApiClientUtil.Registrars;

services.AddMistralOpenApiClientUtilAsSingleton();

IMistralOpenApiClientUtil mistral = serviceProvider
    .GetRequiredService<IMistralOpenApiClientUtil>();

var client = await mistral.Get(cancellationToken);
var models = await client.V1.Models.GetAsync(cancellationToken: cancellationToken);
```

Use `AddMistralOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
