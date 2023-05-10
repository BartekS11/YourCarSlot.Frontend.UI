using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace YourCarSlot.Frontend.UI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>(){ Message = "Invalid data was submitted", 
                    ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Record not found", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something wrong, try again", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            var token = await _localStorage.GetItemAsync<string>("token1");
            System.Console.WriteLine($"TOKEN {token}");
            if (await _localStorage.ContainKeyAsync("token1"))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}