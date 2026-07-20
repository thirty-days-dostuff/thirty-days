using Auth0.AspNetCore.Authentication;
using HelloBlazor.Authentication;
using HelloBlazor.Components;
using HelloBlazor.Data;
using HelloBlazor.Endpoints;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton(new UserDatabase(Path.Combine(builder.Environment.ContentRootPath, "users.db3")));

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
    options.Scope = "openid profile email";
});

builder.Services.Configure<OpenIdConnectOptions>(Auth0Constants.AuthenticationScheme, options =>
{
    var onTokenValidated = options.Events.OnTokenValidated;
    options.Events.OnTokenValidated = async context =>
    {
        if (onTokenValidated is not null)
            await onTokenValidated(context);

        await UserProvisioning.EnsureLocalUserAsync(context);
    };
});

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HelloBlazor.Client._Imports).Assembly);

app.MapUserEndpoints();
app.MapAuthEndpoints();

app.Run();
