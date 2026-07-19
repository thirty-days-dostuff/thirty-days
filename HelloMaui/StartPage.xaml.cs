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
		await Shell.Current.GoToAsync(nameof(LoginPage));
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
