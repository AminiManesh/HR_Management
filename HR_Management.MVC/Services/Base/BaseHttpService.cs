using HR_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            switch (exception.StatusCode)
            {
                case 400:
                    return new Response<Guid>()
                    {
                        StatusCode = exception.StatusCode,
                        Message = exception.Message,
                        ValidationErrors = exception.Response,
                        Success = false
                    };
                    break;
                case 404:
                    return new Response<Guid>()
                    {
                        StatusCode = exception.StatusCode,
                        Message = exception.Message,
                        Success = false
                    };
                    break;
                default:
                    return new Response<Guid>()
                    {
                        StatusCode = exception.StatusCode,
                        Message = exception.Message,
                        Success = false
                    };
                    break;
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
            }
        }
    }
}
