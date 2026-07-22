namespace HelloBlazor.Client.Shared;

public record LoginRequest(string Email, string Password);

public record LoginResponse(bool Success);

public enum Gender
{
	Male,
	Female,
	Diverse
}

public record RegisterRequest(string FirstName, string LastName, DateTime DateOfBirth, Gender Gender);

public record RegisterResponse(bool Success);

public record UserProfileResponse(string Email, string FirstName, string LastName);
