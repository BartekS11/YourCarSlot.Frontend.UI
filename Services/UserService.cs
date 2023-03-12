using Blazored.LocalStorage;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public UserService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}