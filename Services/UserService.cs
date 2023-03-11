using YourCarSlot.Frontend.UI.Contracts;

namespace YourCarSlot.Frontend.UI.Services
{
    public class UserService : IUserService, BaseHttpService
    {
        public UserService(IClient client) : base(client)
        {

        }
    }
}