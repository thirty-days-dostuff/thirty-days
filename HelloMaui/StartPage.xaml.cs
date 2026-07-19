using HelloMaui.Data;
using HelloMaui.Localization;

namespace HelloMaui;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		LanguagePicker.SelectedIndex = LocalizationManager.Instance.Language == AppLanguage.German ? 0 : 1;
	}

	private void OnLanguageChanged(object? sender, EventArgs e)
	{
		LocalizationManager.Instance.Language = LanguagePicker.SelectedIndex == 0
			? AppLanguage.German
			: AppLanguage.English;
	}

	private async void OnLoginClicked(object? sender, EventArgs e)
	{
		var email = EmailEntry.Text?.Trim() ?? string.Empty;
		var password = PasswordEntry.Text ?? string.Empty;

		var user = await UserDatabase.Instance.GetUserByEmailAsync(email);
		var success = user is not null && PasswordHasher.Verify(password, user.PasswordHash, user.PasswordSalt);

		await Shell.Current.GoToAsync($"{nameof(LoginPage)}?success={success}");
	}

	private void OnCredentialsTextChanged(object? sender, TextChangedEventArgs e)
	{
		LoginButton.IsEnabled = !string.IsNullOrWhiteSpace(EmailEntry.Text)
			&& !string.IsNullOrWhiteSpace(PasswordEntry.Text);
	}

	private async void OnForgotPasswordClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ForgotPasswordPage));
	}

	private async void OnRegisterClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(RegistrationPage));
	}
}
