using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                await ((ApiAuthenticationStateProvider)
                    _authenticationStateProvider).LoggedIn();
                return true;
            }
            return false;
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