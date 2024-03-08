using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;

namespace YourCarSlot.Frontend.UI.Pages.ReservationRequests
{
    public partial class EmployeeIndex
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IReservationRequestService ReservationRequestService { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }
        public List<ReservationRequestVM> reservationRequests { get; set; }
        
        [Parameter]
        public Guid id { get; set; }
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
            navigationManager.NavigateTo($"/reservationrequests/edit/{id.ToString()}");
        }

        protected void DetailsReservationRequset(Guid id)
        {
            navigationManager.NavigateTo($"/reservationrequests/details/{id}");
        }

        protected async Task DeleteReservationRequset(Guid id)
        {
            bool confirmed = await JS.InvokeAsync<bool>("confirm", "are u sure");
            if(confirmed)
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
        }


        protected override async Task OnInitializedAsync()
        {
            reservationRequests = await ReservationRequestService.GetAllReservationRequestVMs();
            reservationRequests = reservationRequests.Where(item => item.UserRequestingIdAsString == "4428bf00-b13d-11ed-afa1-0242ac120002").ToList();
            
        }
    }
}