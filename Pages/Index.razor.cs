using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Providers;

namespace YourCarSlot.Frontend.UI.Pages
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IAuthenticationService authenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((ApiAuthenticationStateProvider) authenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void GoToLogin()
        {
            navigationManager.NavigateTo("Login/");
        }

        protected void GoToRegister()
        {
            navigationManager.NavigateTo("Register/");
        }

        protected async void Logout()
        {
            await authenticationService.Logout();
        }
    }
}