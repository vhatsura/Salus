using Salus.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer();

WebApplication app = builder.Build();
app.UseIdentityServer();

app.Run();
