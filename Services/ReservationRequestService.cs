using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourCarSlot.Frontend.UI.Contracts;

namespace YourCarSlot.Frontend.UI.Services
{
    public class ReservationRequestService : IReservationRequestService, BaseHttpService
    {
        public ReservationRequestService(IClient client) : base(client)
        {

        }
    }
}