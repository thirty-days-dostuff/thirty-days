using System.Security.Claims;
using HelloBlazor.Client.Shared;
using HelloBlazor.Data;

namespace HelloBlazor.Endpoints;

public static class UserEndpoints
{
	public static void MapUserEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapGet("/api/users/me", async (HttpContext httpContext, UserDatabase db) =>
		{
			var auth0UserId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (auth0UserId is null)
				return Results.Unauthorized();

			var user = await db.GetUserByAuth0IdAsync(auth0UserId);
			if (user is null)
				return Results.NotFound();

			return Results.Ok(new UserProfileResponse(user.Email, user.FirstName, user.LastName));
		}).RequireAuthorization();

		app.MapPost("/api/users/register", async (RegisterRequest request, UserDatabase db) =>
		{
			if (request.Password != request.PasswordRepeat)
				return Results.Ok(new RegisterResponse(RegisterStatus.PasswordMismatch));

			var email = request.Email.Trim();

			if (await db.EmailExistsAsync(email))
				return Results.Ok(new RegisterResponse(RegisterStatus.EmailAlreadyRegistered));

			var (hash, salt) = PasswordHasher.Hash(request.Password);

			await db.SaveUserAsync(new User
			{
				Email = email,
				PasswordHash = hash,
				PasswordSalt = salt,
				FirstName = request.FirstName.Trim(),
				LastName = request.LastName.Trim()
			});

			return Results.Ok(new RegisterResponse(RegisterStatus.Success));
		}).RequireAuthorization();

		app.MapPost("/api/users/login", async (LoginRequest request, UserDatabase db) =>
		{
			var user = await db.GetUserByEmailAsync(request.Email.Trim());
			var success = user is not null && PasswordHasher.Verify(request.Password, user.PasswordHash, user.PasswordSalt);
			return Results.Ok(new LoginResponse(success));
		});
	}
}
