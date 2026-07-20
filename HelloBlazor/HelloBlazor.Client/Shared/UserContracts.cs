namespace HelloBlazor.Client.Shared;

public record LoginRequest(string Email, string Password);

public record LoginResponse(bool Success);

public record RegisterRequest(string Email, string Password, string PasswordRepeat, string FirstName, string LastName);

public enum RegisterStatus
{
	Success,
	PasswordMismatch,
	EmailAlreadyRegistered
}

public record RegisterResponse(RegisterStatus Status);

public record UserProfileResponse(string Email, string FirstName, string LastName);
