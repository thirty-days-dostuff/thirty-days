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

	public async Task<bool> EmailExistsAsync(string email)
	{
		var connection = await GetConnectionAsync();
		var count = await connection.Table<User>().Where(u => u.Email == email).CountAsync();
		return count > 0;
	}

	public async Task<User?> GetUserByEmailAsync(string email)
	{
		var connection = await GetConnectionAsync();
		return await connection.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
	}

	public async Task SaveUserAsync(User user)
	{
		var connection = await GetConnectionAsync();
		await connection.InsertAsync(user);
	}
}
