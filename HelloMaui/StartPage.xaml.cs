namespace HelloMaui;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(LoginPage));
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
