using SQLite;

namespace HelloMaui.Data;

public sealed class UserDatabase
{
	private SQLiteAsyncConnection? _connection;

	private async Task<SQLiteAsyncConnection> GetConnectionAsync()
	{
		if (_connection is not null)
			return _connection;

		var databasePath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
		_connection = new SQLiteAsyncConnection(databasePath);
		await _connection.CreateTableAsync<User>();
		return _connection;
	}

	public async Task<bool> EmailExistsAsync(string email)
	{
		var connection = await GetConnectionAsync();
		var count = await connection.Table<User>().Where(u => u.Email == email).CountAsync();
		return count > 0;
	}

	public async Task SaveUserAsync(User user)
	{
		var connection = await GetConnectionAsync();
		await connection.InsertAsync(user);
	}
}
