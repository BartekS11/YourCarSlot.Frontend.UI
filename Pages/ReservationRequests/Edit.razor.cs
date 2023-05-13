using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;
using YourCarSlot.Frontend.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace YourCarSlot.Frontend.UI.Pages.ReservationRequests
{
    public partial class Edit
    {
        [Inject]
        IReservationRequestService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public Guid id { get; set; }
        public string Message { get; private set; }

        ReservationRequestVM reservationRequest = new();

        protected async override Task OnParametersSetAsync()
        {
            System.Console.WriteLine(id);
            reservationRequest = await _client.GetReservationRequestVM(id);
        }

        protected async override Task OnInitializedAsync()
        {
            System.Console.WriteLine(id);
            reservationRequest = await _client.GetReservationRequestVM(id);
        }

        async Task ReservationRequestEditForm()
        {
            var response = await _client.UpdateReservationRequest(id, reservationRequest);
            if (response.Success)
            {
                _navManager.NavigateTo("/reservationrequests/");
            }
            Message = response.Message;
        }
    }
}