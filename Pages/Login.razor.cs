using Microsoft.AspNetCore.Components;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;
using YourCarSlot.Frontend.UI.Models.Authentication;

namespace YourCarSlot.Frontend.UI.Pages
{
    public partial class Login
    {
        public Models.Authentication.LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            Model = new Models.Authentication.LoginVM();
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.AuthenticationAsync(Model.Email, Model.Password))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }
    }
}