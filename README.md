[![](https://img.shields.io/nuget/v/soenneker.extensions.ihttpcontextaccessors.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.ihttpcontextaccessors/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.ihttpcontextaccessors/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.ihttpcontextaccessors/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.ihttpcontextaccessors.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.ihttpcontextaccessors/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.ihttpcontextaccessors/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.ihttpcontextaccessors/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.IHttpContextAccessors
Gets the current request's best available client IP address from an injected `IHttpContextAccessor`.

## Installation

```bash
dotnet add package Soenneker.Extensions.IHttpContextAccessors
```

## Usage

```csharp
using Soenneker.Extensions.IHttpContextAccessors;

string? clientIp = httpContextAccessor.GetRequestIp();
```

`GetRequestIp()` delegates to the companion `HttpContext` extension. It checks proxy headers such as `CF-Connecting-IP` and `X-Forwarded-For`, then falls back to the connection's remote IP. It returns `null` when there is no active `HttpContext` or no address can be found.

Forwarded headers are caller-controlled unless your proxy and ASP.NET Core forwarded-header configuration establish trust. Do not treat the returned text as authenticated identity by itself.
