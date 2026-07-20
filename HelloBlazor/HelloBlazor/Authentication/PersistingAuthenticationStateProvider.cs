using System.Security.Claims;
using HelloBlazor.Client.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;

namespace HelloBlazor.Authentication;

internal sealed class PersistingAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
	private readonly PersistingComponentStateSubscription _subscription;

	public PersistingAuthenticationStateProvider(PersistentComponentState state)
	{
		_subscription = state.RegisterOnPersisting(() => OnPersistingAsync(state), RenderMode.InteractiveWebAssembly);
	}

	private async Task OnPersistingAsync(PersistentComponentState state)
	{
		var principal = (await GetAuthenticationStateAsync()).User;

		if (principal.Identity?.IsAuthenticated != true)
			return;

		var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		var name = principal.Identity.Name;

		if (userId is null || name is null)
			return;

		state.PersistAsJson(nameof(UserInfo), new UserInfo(
			userId,
			name,
			principal.FindFirst(ClaimTypes.Email)?.Value,
			principal.FindFirst("picture")?.Value));
	}

	public void Dispose() => _subscription.Dispose();
}
