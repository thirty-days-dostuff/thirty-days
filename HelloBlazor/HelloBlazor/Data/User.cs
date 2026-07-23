using HelloBlazor.Client.Shared;
using SQLite;

namespace HelloBlazor.Data;

public class User
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	[Indexed(Unique = true)]
	public string? Auth0UserId { get; set; }

	[Indexed(Unique = true)]
	public string Email { get; set; } = string.Empty;

	public string PasswordHash { get; set; } = string.Empty;

	public string PasswordSalt { get; set; } = string.Empty;

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public DateTime DateOfBirth { get; set; }

	public Gender Gender { get; set; }

	public GenderInterest InterestedIn { get; set; }
}
