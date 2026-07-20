using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HelloBlazor.Endpoints;

public static class AuthEndpoints
{
	public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
		{
			var redirectUri = returnUrl.StartsWith('/') ? returnUrl : "/";

			var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
				.WithRedirectUri(redirectUri)
				.Build();

			await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
		});

		app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
		{
			var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
				.WithRedirectUri("/")
				.Build();

			await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
			await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}).RequireAuthorization();
	}
}
