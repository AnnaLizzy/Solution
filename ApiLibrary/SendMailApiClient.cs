using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using WebApplicationAPI.Constants;

namespace ApiLibrary
{
    public class SendMailApiClient(HttpClient httpClient, 
        IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient,httpClientFactory), IMailSenderApiClient
    {
        private readonly IHttpClientFactory _httpclientFactory = httpClientFactory;
        public async Task<bool> SendMail(SendMailViewModel model)
        {
            var client = _httpclientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
            if (model == null)
            {
                return false;
            }
            var request = new MultipartFormDataContent
            {
                { new StringContent(model.To ?? ""),"To" },
                { new StringContent(model.Subject ?? ""),"Subject" },
                { new StringContent(model.Body ?? ""),"Body" },
               
            };
            var respone = await client.PostAsync("api/PowerManager/Send", request);
            return respone.IsSuccessStatusCode;
        }
    }
}
