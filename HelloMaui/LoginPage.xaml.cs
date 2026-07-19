namespace HelloMaui;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
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
