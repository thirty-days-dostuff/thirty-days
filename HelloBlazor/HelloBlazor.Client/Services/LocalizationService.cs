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

	public string WelcomeHeadline => _language == AppLanguage.German ? "Finde deinen Menschen" : "Find your person";

	public string WelcomeTagline => _language == AppLanguage.German
		? "Echte Verbindungen beginnen mit einem Hallo. Lass uns deins finden."
		: "Real connections start with a hello. Let's find yours.";

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

	public string DifferentiationHeading => _language == AppLanguage.German
		? "Gibts nicht schon genug Dating Apps? Was machen wir anders?"
		: "Aren't there enough dating apps already? What do we do differently?";

	public string DifferentiationIntro => _language == AppLanguage.German
		? "Ganz ehrlich: ja, davon gibt's genug. Uns geht's nicht ums endlose Wischen, sondern um echte Verbindungen:"
		: "Honestly? Sure, there are plenty. We're not about endless swiping – we're about real connections:";

	public IReadOnlyList<string> DifferentiationItems => _language == AppLanguage.German
		?
		[
			"Verifizierte Profile statt Fake-Accounts – dank Login über Auth0",
			"Klare Angaben statt Rätselraten: Geschlecht und Interessen auf einen Blick",
			"Fokus auf Qualität statt Quantität bei den Matches"
		]
		:
		[
			"Verified profiles instead of fake accounts, thanks to Auth0 login",
			"No guessing games: gender and interests visible at a glance",
			"Quality over quantity when it comes to matches"
		];

	public string ImpressumLinkText => _language == AppLanguage.German ? "Impressum" : "Legal notice";

	public string ImpressumPageTitle => _language == AppLanguage.German ? "Impressum" : "Legal notice";

	public string CompanyNameLabel => _language == AppLanguage.German ? "Firma" : "Company";

	public string AddressLabel => _language == AppLanguage.German ? "Anschrift" : "Address";

	public string RepresentativeLabel => _language == AppLanguage.German ? "Vertretungsberechtigt" : "Represented by";

	public string PhoneLabel => _language == AppLanguage.German ? "Telefon" : "Phone";

	public string EmailLabel => _language == AppLanguage.German ? "E-Mail" : "Email";

	public string CommercialRegisterNumberLabel => _language == AppLanguage.German ? "Handelsregisternummer" : "Commercial register number";

	public string VatIdLabel => _language == AppLanguage.German ? "USt-IdNr." : "VAT ID";

	public string DatenschutzLinkText => _language == AppLanguage.German ? "Datenschutzerklärung" : "Privacy policy";

	public string DatenschutzPageTitle => _language == AppLanguage.German ? "Datenschutzerklärung" : "Privacy policy";

	public string ControllerHeading => _language == AppLanguage.German
		? "Verantwortlicher für die Datenverarbeitung"
		: "Controller responsible for data processing";

	public string DataCollectedHeading => _language == AppLanguage.German ? "Welche Daten erhoben werden" : "What data is collected";

	public IReadOnlyList<string> DataCollectedItems => _language == AppLanguage.German
		?
		[
			"Über die Anmeldung mit Auth0: Name, E-Mail-Adresse und eine eindeutige Benutzer-ID",
			"Im Rahmen der Profilregistrierung: Vorname, Nachname, Geburtsdatum, Geschlecht und das Geschlecht, an dem Interesse besteht"
		]
		:
		[
			"Via Auth0 login: name, email address and a unique user ID",
			"As part of profile registration: first name, last name, date of birth, gender and the gender you're interested in"
		];

	public string PurposeHeading => _language == AppLanguage.German ? "Warum die Daten verarbeitet werden" : "Why the data is processed";

	public IReadOnlyList<string> PurposeItems => _language == AppLanguage.German
		?
		[
			"Erstellung und Verwaltung Ihres Benutzerkontos",
			"Authentifizierung und Absicherung des Logins",
			"Bereitstellung personalisierter Funktionen der Anwendung"
		]
		:
		[
			"Creating and managing your user account",
			"Authenticating and securing the login",
			"Providing personalized features of the application"
		];

	public string LegalBasisHeading => _language == AppLanguage.German ? "Rechtsgrundlage (DSGVO)" : "Legal basis (GDPR)";

	public IReadOnlyList<string> LegalBasisItems => _language == AppLanguage.German
		?
		[
			"Art. 6 Abs. 1 lit. b DSGVO (Erfüllung eines Vertrags bzw. vorvertragliche Maßnahmen) für die Kontoerstellung und -verwaltung",
			"Art. 6 Abs. 1 lit. f DSGVO (berechtigtes Interesse) für die Absicherung des Logins, z. B. zur Betrugsprävention"
		]
		:
		[
			"Art. 6(1)(b) GDPR (performance of a contract / pre-contractual measures) for account creation and management",
			"Art. 6(1)(f) GDPR (legitimate interest) for securing the login, e.g. fraud prevention"
		];

	public string RetentionHeading => _language == AppLanguage.German ? "Speicherdauer" : "Storage duration";

	public string RetentionText => _language == AppLanguage.German
		? "Die Daten werden gespeichert, solange Ihr Benutzerkonto besteht. Nach Löschung des Kontos werden die Daten entfernt, sofern keine gesetzlichen Aufbewahrungspflichten entgegenstehen."
		: "The data is stored for as long as your user account exists. Once the account is deleted, the data is removed unless legal retention obligations require otherwise.";

	public string RecipientsHeading => _language == AppLanguage.German ? "Empfänger der Daten" : "Recipients of the data";

	public IReadOnlyList<string> RecipientsItems => _language == AppLanguage.German
		?
		[
			"Auth0 (Okta, Inc.) als Auftragsverarbeiter für die Authentifizierung",
			"Der Hosting-Anbieter dieser Anwendung"
		]
		:
		[
			"Auth0 (Okta, Inc.) as processor for authentication",
			"The hosting provider of this application"
		];

	public string RightsHeading => _language == AppLanguage.German ? "Betroffenenrechte" : "Your rights";

	public IReadOnlyList<string> RightsItems => _language == AppLanguage.German
		?
		[
			"Recht auf Auskunft (Art. 15 DSGVO)",
			"Recht auf Berichtigung (Art. 16 DSGVO)",
			"Recht auf Löschung (Art. 17 DSGVO)",
			"Recht auf Einschränkung der Verarbeitung (Art. 18 DSGVO)",
			"Recht auf Datenübertragbarkeit (Art. 20 DSGVO)",
			"Recht auf Widerspruch (Art. 21 DSGVO)",
			"Recht auf Beschwerde bei einer Aufsichtsbehörde (Art. 77 DSGVO)"
		]
		:
		[
			"Right of access (Art. 15 GDPR)",
			"Right to rectification (Art. 16 GDPR)",
			"Right to erasure (Art. 17 GDPR)",
			"Right to restriction of processing (Art. 18 GDPR)",
			"Right to data portability (Art. 20 GDPR)",
			"Right to object (Art. 21 GDPR)",
			"Right to lodge a complaint with a supervisory authority (Art. 77 GDPR)"
		];

	public string CookiesHeading => _language == AppLanguage.German ? "Cookies" : "Cookies";

	public string CookiesIntro => _language == AppLanguage.German
		? "Diese Anwendung verwendet ausschließlich technisch notwendige Cookies, die für den Betrieb und die Absicherung des Logins erforderlich sind. Ein Einwilligungs-Banner ist dafür nicht erforderlich, da keine Analyse-, Marketing- oder Tracking-Cookies eingesetzt werden."
		: "This application only uses strictly necessary cookies required to operate and secure the login. No consent banner is required for these, since no analytics, marketing or tracking cookies are used.";

	public IReadOnlyList<string> CookiesItems => _language == AppLanguage.German
		?
		[
			".AspNetCore.Cookies – hält die Anmeldesitzung nach dem Login aufrecht",
			".AspNetCore.OpenIdConnect.Nonce.* – schützt den Auth0-Login-Vorgang vor Replay-Angriffen (nur während des Logins)",
			".AspNetCore.Correlation.* – schützt den Auth0-Login-Vorgang vor CSRF-Angriffen (nur während des Logins)",
			".AspNetCore.Antiforgery.* – schützt Formulareingaben vor CSRF-Angriffen"
		]
		:
		[
			".AspNetCore.Cookies – keeps you signed in after login",
			".AspNetCore.OpenIdConnect.Nonce.* – protects the Auth0 login flow against replay attacks (only during login)",
			".AspNetCore.Correlation.* – protects the Auth0 login flow against CSRF attacks (only during login)",
			".AspNetCore.Antiforgery.* – protects form submissions against CSRF attacks"
		];

	public string ContactHeading => _language == AppLanguage.German ? "Kontakt für Datenschutzanfragen" : "Contact for privacy inquiries";

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
