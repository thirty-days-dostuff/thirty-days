using System.Security.Claims;
using HelloBlazor.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace HelloBlazor.Authentication;

public static class UserProvisioning
{
	public static async Task EnsureLocalUserAsync(TokenValidatedContext context)
	{
		var principal = context.Principal;
		var auth0UserId = principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		if (auth0UserId is null)
			return;

		var db = context.HttpContext.RequestServices.GetRequiredService<UserDatabase>();

		await db.EnsureUserForAuth0LoginAsync(
			auth0UserId,
			principal!.FindFirst(ClaimTypes.Email)?.Value,
			principal.FindFirst(ClaimTypes.GivenName)?.Value,
			principal.FindFirst(ClaimTypes.Surname)?.Value);
	}
}
