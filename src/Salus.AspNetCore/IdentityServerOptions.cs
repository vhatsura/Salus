namespace Salus.AspNetCore;

public class AuthenticationOptions
{
    public string? Scheme { get; set; }
}

public class IdentityServerOptions
{
    public AuthenticationOptions Authentication { get; set; } = new();
}
