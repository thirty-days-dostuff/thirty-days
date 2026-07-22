namespace HelloBlazor.Client.Shared;

public record LoginRequest(string Email, string Password);

public record LoginResponse(bool Success);

public record RegisterRequest(string FirstName, string LastName, DateTime DateOfBirth);

public record RegisterResponse(bool Success);

public record UserProfileResponse(string Email, string FirstName, string LastName);
