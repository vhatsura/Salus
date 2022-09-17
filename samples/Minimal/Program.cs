using Salus.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
    });

WebApplication app = builder.Build();
app.UseIdentityServer();

app.MapGet("/health", () => "Hello, World!");

app.Run();
