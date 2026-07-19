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

	public string PasswordRepeatPlaceholder => _language == AppLanguage.German ? "Passwort wiederholen" : "Repeat password";

	public string FirstNamePlaceholder => _language == AppLanguage.German ? "Vorname" : "First name";

	public string LastNamePlaceholder => _language == AppLanguage.German ? "Nachname" : "Last name";

	public string RegisterNowButtonText => _language == AppLanguage.German ? "Jetzt registrieren" : "Register now";

	public string LoginButtonText => "Login";

	public string ForgotPasswordButtonText => _language == AppLanguage.German ? "Passwort vergessen?" : "Forgot password?";

	public string RegisterButtonText => _language == AppLanguage.German ? "Registrieren" : "Register";

	public string RegistrationPageTitle => _language == AppLanguage.German ? "Registrierung" : "Registration";

	public string ForgotPasswordPageTitle => _language == AppLanguage.German ? "Passwort zurücksetzen" : "Reset password";

	public string LoginPageTitle => "Login";

	public string OkButtonText => "OK";

	public string RegistrationErrorTitle => _language == AppLanguage.German ? "Fehler" : "Error";

	public string PasswordMismatchMessage => _language == AppLanguage.German
		? "Die Passwörter stimmen nicht überein."
		: "The passwords do not match.";

	public string EmailAlreadyRegisteredMessage => _language == AppLanguage.German
		? "Diese E-Mail-Adresse ist bereits registriert."
		: "This email address is already registered.";

	public string RegistrationSuccessTitle => _language == AppLanguage.German ? "Erfolg" : "Success";

	public string RegistrationSuccessMessage => _language == AppLanguage.German
		? "Registrierung erfolgreich."
		: "Registration successful.";

	public string LoginSuccessMessage => _language == AppLanguage.German
		? "Erfolgreich angemeldet"
		: "Successfully signed in";

	public string LoginFailureMessage => _language == AppLanguage.German
		? "Nicht erfolgreich"
		: "Not successful";
}
