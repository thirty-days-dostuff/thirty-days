using System.Security.Cryptography;

namespace HelloMaui.Data;

public static class PasswordHasher
{
	private const int SaltSize = 16;
	private const int HashSize = 32;
	private const int Iterations = 100_000;

	public static (string Hash, string Salt) Hash(string password)
	{
		var salt = RandomNumberGenerator.GetBytes(SaltSize);
		var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
		return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
	}
}
