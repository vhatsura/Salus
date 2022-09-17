# Salus

Identity Server implementing [OAuth 2.1](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-05)
and [OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0.html) specifications.
Salus, in Roman religion, was the goddess of safety and welfare.

The project is developing as an alternative to [IdentityServer4](https://github.com/IdentityServer/IdentityServer4),
which will reach the end of support on the 3rd Dec 2022.

## Installation

```powershell
Install-Package Salus.AspNetCore
```

## Usage

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer();

var app = builder.Build();
app.UseIdentityServer();

app.Run();
```

## Roadmap

* [ ] [Authorization Code Grant](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-05#section-4.1)
* [ ] [Client Credentials Grant](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-05#section-4.2)
* [ ] [Refresh Token Grant](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-05#section-4.3)
* [ ] [Authorization Server Metadata](https://datatracker.ietf.org/doc/html/rfc8414)
* [ ] [Extension mechanism for additional grant types](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-v2-1-05#section-4.4)

## Contributing
