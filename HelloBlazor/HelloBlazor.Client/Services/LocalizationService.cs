namespace HelloBlazor.Client.Services;

public sealed class LocalizationService
{
	private AppLanguage _language = AppLanguage.German;

	public event Action? OnChange;

	public AppLanguage Language
	{
		get => _language;
		set
		{
			if (_language == value)
				return;

			_language = value;
			OnChange?.Invoke();
		}
	}

	public string LanguageLabel => _language == AppLanguage.German ? "Sprache" : "Language";

	public string StartPageTitle => _language == AppLanguage.German ? "Anmelden" : "Sign in";

	public string EmailPlaceholder => _language == AppLanguage.German ? "E-Mail" : "Email";

	public string PasswordPlaceholder => _language == AppLanguage.German ? "Passwort" : "Password";

	public string PasswordRepeatPlaceholder => _language == AppLanguage.German ? "Passwort wiederholen" : "Repeat password";

	public string FirstNamePlaceholder => _language == AppLanguage.German ? "Vorname" : "First name";

	public string LastNamePlaceholder => _language == AppLanguage.German ? "Nachname" : "Last name";

	public string LoginButtonText => "Login";

	public string ForgotPasswordLinkText => _language == AppLanguage.German ? "Passwort vergessen?" : "Forgot password?";

	public string RegisterLinkText => _language == AppLanguage.German ? "Registrieren" : "Register";

	public string RegisterNowButtonText => _language == AppLanguage.German ? "Jetzt registrieren" : "Register now";

	public string RegistrationPageTitle => _language == AppLanguage.German ? "Registrierung" : "Registration";

	public string ForgotPasswordPageTitle => _language == AppLanguage.German ? "Passwort zurücksetzen" : "Reset password";

	public string LoginPageTitle => "Login";

	public string PasswordMismatchMessage => _language == AppLanguage.German
		? "Die Passwörter stimmen nicht überein."
		: "The passwords do not match.";

	public string EmailAlreadyRegisteredMessage => _language == AppLanguage.German
		? "Diese E-Mail-Adresse ist bereits registriert."
		: "This email address is already registered.";

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
