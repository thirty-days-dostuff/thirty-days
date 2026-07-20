using System.Security.Claims;
using HelloBlazor.Client.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HelloBlazor.Client.Authentication;

internal sealed class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
	private static readonly Task<AuthenticationState> UnauthenticatedTask =
		Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

	private readonly Task<AuthenticationState> _authenticationStateTask = UnauthenticatedTask;

	public PersistentAuthenticationStateProvider(PersistentComponentState state)
	{
		if (!state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo) || userInfo is null)
			return;

		var identity = new ClaimsIdentity(
			authenticationType: nameof(PersistentAuthenticationStateProvider),
			nameType: ClaimTypes.Name,
			roleType: ClaimTypes.Role);

		identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userInfo.UserId));
		identity.AddClaim(new Claim(ClaimTypes.Name, userInfo.Name));

		if (userInfo.Email is not null)
			identity.AddClaim(new Claim(ClaimTypes.Email, userInfo.Email));

		if (userInfo.Picture is not null)
			identity.AddClaim(new Claim("picture", userInfo.Picture));

		_authenticationStateTask = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
	}

	public override Task<AuthenticationState> GetAuthenticationStateAsync() => _authenticationStateTask;
}
