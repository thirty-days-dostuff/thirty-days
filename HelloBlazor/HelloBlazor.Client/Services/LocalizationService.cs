using HelloBlazor.Client.Shared;

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

	public string FirstNamePlaceholder => _language == AppLanguage.German ? "Vorname" : "First name";

	public string LastNamePlaceholder => _language == AppLanguage.German ? "Nachname" : "Last name";

	public string DateOfBirthPlaceholder => _language == AppLanguage.German ? "Geburtsdatum" : "Date of birth";

	public string GenderPlaceholder => _language == AppLanguage.German ? "Geschlecht" : "Gender";

	public string GenderName(Gender gender) => gender switch
	{
		Gender.Male => _language == AppLanguage.German ? "Männlich" : "Male",
		Gender.Female => _language == AppLanguage.German ? "Weiblich" : "Female",
		Gender.Diverse => _language == AppLanguage.German ? "Divers" : "Diverse",
		_ => gender.ToString()
	};

	public string InterestedInPlaceholder => _language == AppLanguage.German ? "Interessiert an" : "Interested in";

	public string InterestName(GenderInterest interest) => interest switch
	{
		GenderInterest.Male => _language == AppLanguage.German ? "Männer" : "Men",
		GenderInterest.Female => _language == AppLanguage.German ? "Frauen" : "Women",
		GenderInterest.Diverse => _language == AppLanguage.German ? "Divers" : "Diverse",
		_ => interest.ToString()
	};

	public string LoginButtonText => "Login";

	public string LogoutButtonText => "Logout";

	public string ForgotPasswordLinkText => _language == AppLanguage.German ? "Passwort vergessen?" : "Forgot password?";

	public string RegisterLinkText => _language == AppLanguage.German ? "Registrieren" : "Register";

	public string RegisterNowButtonText => _language == AppLanguage.German ? "Jetzt registrieren" : "Register now";

	public string RegistrationPageTitle => _language == AppLanguage.German ? "Registrierung" : "Registration";

	public string ForgotPasswordPageTitle => _language == AppLanguage.German ? "Passwort zurücksetzen" : "Reset password";

	public string LoginPageTitle => "Login";

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
