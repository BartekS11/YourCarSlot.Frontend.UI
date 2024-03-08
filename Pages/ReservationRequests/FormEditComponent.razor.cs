using YourCarSlot.Frontend.UI.Models;
using Microsoft.AspNetCore.Components;

namespace YourCarSlot.Frontend.UI.Pages.ReservationRequests
{
    public partial class FormEditComponent
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public ReservationRequestVM ReservationRequest { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}