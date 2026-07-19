using SQLite;

namespace HelloMaui.Data;

public class User
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	[Indexed(Unique = true)]
	public string Email { get; set; } = string.Empty;

	public string PasswordHash { get; set; } = string.Empty;

	public string PasswordSalt { get; set; } = string.Empty;

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;
}
