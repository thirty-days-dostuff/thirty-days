using HelloMaui.Data;
using HelloMaui.Localization;

namespace HelloMaui;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();

#if DEBUG
		// TODO: remove test data prefill before shipping.
		EmailEntry.Text = $"test-{DateTime.Now:HHmmss}@example.com";
		PasswordEntry.Text = "Test1234!";
		PasswordRepeatEntry.Text = "Test1234!";
		FirstNameEntry.Text = "Max";
		LastNameEntry.Text = "Mustermann";
#endif
	}

	private async void OnRegisterNowClicked(object? sender, EventArgs e)
	{
		var loc = LocalizationManager.Instance;

		if (PasswordEntry.Text != PasswordRepeatEntry.Text)
		{
			await DisplayAlertAsync(loc.RegistrationErrorTitle, loc.PasswordMismatchMessage, loc.OkButtonText);
			return;
		}

		var email = EmailEntry.Text?.Trim() ?? string.Empty;

		if (await UserDatabase.Instance.EmailExistsAsync(email))
		{
			await DisplayAlertAsync(loc.RegistrationErrorTitle, loc.EmailAlreadyRegisteredMessage, loc.OkButtonText);
			return;
		}

		var (hash, salt) = PasswordHasher.Hash(PasswordEntry.Text ?? string.Empty);

		var user = new User
		{
			Email = email,
			PasswordHash = hash,
			PasswordSalt = salt,
			FirstName = FirstNameEntry.Text?.Trim() ?? string.Empty,
			LastName = LastNameEntry.Text?.Trim() ?? string.Empty
		};

		await UserDatabase.Instance.SaveUserAsync(user);

		await DisplayAlertAsync(loc.RegistrationSuccessTitle, loc.RegistrationSuccessMessage, loc.OkButtonText);
	}
}
