using SQLite;

namespace HelloBlazor.Data;

public sealed class UserDatabase
{
	private readonly string _databasePath;
	private SQLiteAsyncConnection? _connection;

	public UserDatabase(string databasePath)
	{
		_databasePath = databasePath;
	}

	private async Task<SQLiteAsyncConnection> GetConnectionAsync()
	{
		if (_connection is not null)
			return _connection;

		_connection = new SQLiteAsyncConnection(_databasePath);
		await _connection.CreateTableAsync<User>();
		return _connection;
	}

	public async Task<User?> GetUserByEmailAsync(string email)
	{
		var connection = await GetConnectionAsync();
		return await connection.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
	}

	public async Task<User?> GetUserByAuth0IdAsync(string auth0UserId)
	{
		var connection = await GetConnectionAsync();
		return await connection.Table<User>().Where(u => u.Auth0UserId == auth0UserId).FirstOrDefaultAsync();
	}

	public async Task UpdateUserAsync(User user)
	{
		var connection = await GetConnectionAsync();
		await connection.UpdateAsync(user);
	}

	public async Task<User> EnsureUserForAuth0LoginAsync(string auth0UserId, string? email, string? firstName, string? lastName)
	{
		var connection = await GetConnectionAsync();

		var existing = await connection.Table<User>().Where(u => u.Auth0UserId == auth0UserId).FirstOrDefaultAsync();
		if (existing is not null)
			return existing;

		// Link an existing password-based account created before Auth0, if the email matches.
		if (email is not null)
		{
			var byEmail = await connection.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
			if (byEmail is not null)
			{
				byEmail.Auth0UserId = auth0UserId;
				await connection.UpdateAsync(byEmail);
				return byEmail;
			}
		}

		var user = new User
		{
			Auth0UserId = auth0UserId,
			Email = email ?? string.Empty,
			FirstName = firstName ?? string.Empty,
			LastName = lastName ?? string.Empty
		};

		await connection.InsertAsync(user);
		return user;
	}
}
