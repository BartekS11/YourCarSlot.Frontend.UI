using AutoMapper;
using Blazored.LocalStorage;
using YourCarSlot.Frontend.UI.Contracts;
using YourCarSlot.Frontend.UI.Models;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.Services
{
    public class ReservationRequestService : BaseHttpService, IReservationRequestService
    {
        private readonly IMapper _mapper;

        public ReservationRequestService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateReservationRequest(ReservationRequestVM reservationRequestVM)
        {
            try
            {
                await AddBearerToken();
                var createReservationRequestCommand = _mapper.Map<CreateReservationCommand>(reservationRequestVM);
                await _client.ReservationRequestPOSTAsync(createReservationRequestCommand);
                return new Response<Guid>() 
                { 
                    Success = true
                };                
            }
            catch (ApiException ex)
            {   
                return ConvertApiExceptions<Guid>(ex);
            }

        }

        public async Task<Response<Guid>> DeleteReservationRequest(Guid id)
        {
            try
            {
                await AddBearerToken();
                await _client.ReservationRequestDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<ReservationRequestVM>> GetAllReservationRequestVMs()
        {
            await AddBearerToken();
            var reservationRequestsVM = await _client.ReservationRequestAllAsync();

            return _mapper.Map<List<ReservationRequestVM>>(reservationRequestsVM);
        }

        public async Task<ReservationRequestVM> GetReservationRequestVM(Guid id)
        {
            await AddBearerToken();
            var reservationRequestVM = await _client.ReservationRequestGETAsync(id);

            return _mapper.Map<ReservationRequestVM>(reservationRequestVM); 
        }

        public async Task<Response<Guid>> UpdateReservationRequest(Guid id, ReservationRequestVM reservationRequestVM)
        {
            try
            {
                await AddBearerToken();
                var updateReservationRequestCommand = _mapper.Map<UpdateReservationCommand>(reservationRequestVM);
                await _client.ReservationRequestPUTAsync(updateReservationRequestCommand);
                return new Response<Guid>() 
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {   
                return ConvertApiExceptions<Guid>(ex);
            }



        }
    }
}