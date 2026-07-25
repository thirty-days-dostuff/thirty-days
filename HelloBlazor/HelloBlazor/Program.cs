using Auth0.AspNetCore.Authentication;
using HelloBlazor.Authentication;
using HelloBlazor.Components;
using HelloBlazor.Data;
using HelloBlazor.Endpoints;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton(new UserDatabase(Path.Combine(builder.Environment.ContentRootPath, "users.db3")));

builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
});

var otel = builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation())
    .WithMetrics(metrics => metrics
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation());

// Exports via OTLP when OTEL_EXPORTER_OTLP_ENDPOINT (and related OTEL_* env vars) are set.
// See https://opentelemetry.io/docs/languages/sdk-configuration/otlp-exporter/
if (!string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
{
    otel.UseOtlpExporter();
}
else if (builder.Environment.IsDevelopment())
{
    otel.WithTracing(tracing => tracing.AddConsoleExporter());
    otel.WithMetrics(metrics => metrics.AddConsoleExporter());
}

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
app.MapCompanyEndpoints();

app.Run();
