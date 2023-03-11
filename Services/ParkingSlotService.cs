using YourCarSlot.Frontend.UI.Contracts;

namespace YourCarSlot.Frontend.UI.Services
{
    public class ParkingSlotService : IParkingSlotService, BaseHttpService
    {
        public ParkingSlotService(IClient client) : base(client)
        {

        }
    }
}