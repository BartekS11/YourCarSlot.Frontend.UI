using Blazored.LocalStorage;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Services
{
    public class VehicleService : BaseHttpService, IVehicleService 
    {
        public VehicleService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}