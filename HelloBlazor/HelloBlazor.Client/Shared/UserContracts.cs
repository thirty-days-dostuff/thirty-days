namespace HelloBlazor.Client.Shared;

public record LoginRequest(string Email, string Password);

public record LoginResponse(bool Success);

public enum Gender
{
	Male,
	Female,
	Diverse
}

[Flags]
public enum GenderInterest
{
	None = 0,
	Male = 1,
	Female = 2,
	Diverse = 4
}

public record RegisterRequest(string FirstName, string LastName, DateTime DateOfBirth, Gender Gender, GenderInterest InterestedIn);

public record RegisterResponse(bool Success);

public record UserProfileResponse(string Email, string FirstName, string LastName);
