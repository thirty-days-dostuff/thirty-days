using HelloMaui.Localization;

namespace HelloMaui;

[QueryProperty(nameof(Success), "success")]
public partial class LoginPage : ContentPage
{
	public string Success
	{
		set
		{
			var isSuccess = bool.TryParse(value, out var result) && result;
			StatusLabel.Text = isSuccess
				? LocalizationManager.Instance.LoginSuccessMessage
				: LocalizationManager.Instance.LoginFailureMessage;
		}
	}

	public LoginPage()
	{
		InitializeComponent();
	}
}
