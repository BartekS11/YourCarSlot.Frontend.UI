using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourCarSlot.Frontend.UI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticationAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}