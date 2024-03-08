using YourCarSlot.Frontend.UI.Models;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Contracts
{
    public interface IReservationRequestService
    {
        Task<List<ReservationRequestVM>> GetAllReservationRequestVMs();
        Task<ReservationRequestVM> GetReservationRequestVM(Guid id);
        Task<Response<Guid>> CreateReservationRequest(ReservationRequestVM reservationRequestVM);
        Task<Response<Guid>> UpdateReservationRequest(Guid id, ReservationRequestVM reservationRequestVM);
        Task<Response<Guid>> DeleteReservationRequest(Guid id);
    }
}