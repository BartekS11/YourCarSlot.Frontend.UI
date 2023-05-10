using Microsoft.AspNetCore.Components;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;

namespace YourCarSlot.Frontend.UI.Pages.ReservationRequests
{
    public partial class Index
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IReservationRequestService ReservationRequestService { get; set; }
        public List<ReservationRequestVM> reservationRequests { get; set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateReservationRequest()
        {
            navigationManager.NavigateTo("/reservationrequests/create/");
        }

        protected void AllocateReservationRequset(Guid id)
        {

        }

        protected void EditReservationRequset(Guid id)
        {
            navigationManager.NavigateTo($"/reservationrequests/edit/{id}");
        }

        protected void DetailsReservationRequset(Guid id)
        {
            navigationManager.NavigateTo($"/reservationrequests/details/{id}");
        }

        protected async Task DeleteReservationRequset(Guid id)
        {
            var response = await ReservationRequestService.DeleteReservationRequest(id);
            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            System.Console.WriteLine("rsrfafasf");
            reservationRequests = await ReservationRequestService.GetAllReservationRequestVMs();
        }
    }
}