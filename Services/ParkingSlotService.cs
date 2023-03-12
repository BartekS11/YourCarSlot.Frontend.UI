using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Services
{
    public class ParkingSlotService : BaseHttpService, IParkingSlotService
    {
        public ParkingSlotService(IClient client) : base(client)
        {

        }
    }
}