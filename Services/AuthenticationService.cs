using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Providers;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, 
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            this._authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticationAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                var authToken = authenticationResponse.Token;
                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token1", $"{authToken}");
                    await _localStorage.SetItemAsync("token", $"{authToken}");

                    await ((ApiAuthenticationStateProvider)
                        _authenticationStateProvider).LoggedIn();
                    System.Console.WriteLine(authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            // await _localStorage.RemoveItemAsync("token");
            await ((ApiAuthenticationStateProvider)
                    _authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName,
                UserName = userName, Email = email, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}