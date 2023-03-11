using YourCarSlot.Frontend.UI.Contracts;

namespace YourCarSlot.Frontend.UI.Services
{
    public class VehicleService : IVehicleService, BaseHttpService
    {
        public VehicleService(IClient client) : base(client)
        {

        }
    }
}