using HelloBlazor.Client.Shared;
using HelloBlazor.Data;

namespace HelloBlazor.Endpoints;

public static class UserEndpoints
{
	public static void MapUserEndpoints(this IEndpointRouteBuilder app)
	{
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
