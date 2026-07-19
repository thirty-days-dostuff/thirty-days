using System.ComponentModel;

namespace HelloMaui.Localization;

public sealed class LocalizationManager : INotifyPropertyChanged
{
	public static LocalizationManager Instance { get; } = new();

	private AppLanguage _language = AppLanguage.German;

	private LocalizationManager()
	{
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public AppLanguage Language
	{
		get => _language;
		set
		{
			if (_language == value)
				return;

			_language = value;

			// Empty property name is the WPF/MAUI binding-engine convention for
			// "every bound property may have changed" - refreshes all labels at once.
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
		}
	}

	public string LanguagePickerTitle => _language == AppLanguage.German ? "Sprache" : "Language";

	public string StartPageTitle => _language == AppLanguage.German ? "Anmelden" : "Sign in";

	public string EmailPlaceholder => _language == AppLanguage.German ? "E-Mail" : "Email";

	public string PasswordPlaceholder => _language == AppLanguage.German ? "Passwort" : "Password";

	public string LoginButtonText => "Login";

	public string ForgotPasswordButtonText => _language == AppLanguage.German ? "Passwort vergessen?" : "Forgot password?";

	public string RegisterButtonText => _language == AppLanguage.German ? "Registrieren" : "Register";

	public string RegistrationPageTitle => _language == AppLanguage.German ? "Registrierung" : "Registration";

	public string ForgotPasswordPageTitle => _language == AppLanguage.German ? "Passwort zurücksetzen" : "Reset password";

	public string LoginPageTitle => "Login";
}
