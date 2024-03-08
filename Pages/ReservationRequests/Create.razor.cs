using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using YourCarSlot.Frontend.UI;
using YourCarSlot.Frontend.UI.Shared;
using System.Net;
using System.Numerics;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;

namespace YourCarSlot.Frontend.UI.Pages.ReservationRequests
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        IReservationRequestService _client { get; set; }
        public string Message { get; private set; }

        ReservationRequestVM reservationRequest = new();
        async Task CreateReservationRequestForm()
        {
            var response = await _client.CreateReservationRequest(reservationRequest);
            if(response.Success)
            {
                _navManager.NavigateTo("/reservationrequests/");
            }
            Message = response.Message;
        }
    }
}