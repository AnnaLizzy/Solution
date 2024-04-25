using ApiLibrary.Constants;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebApplicationAPI.Constants;
namespace ApiLibrary
{
    public class BaseApiClient(HttpClient httpClient,IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _baseUrl = SystemConstants.Url.BaseApiUrl;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        public async Task<T?> GetAsync<T>(string url)
        {
            
            _httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data) ?? throw new Exception("Error");
            }
            return default;
        }
        public async Task<T?> PostAsync<T>(string url, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, ApiConst.Setting.StringContent);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);            
     
            var response = await _httpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default;
        }
        public async Task<T?> PutAsync<T>(string url, object obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            var content = new StringContent(data, Encoding.UTF8, ApiConst.Setting.StringContent);
            var response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default;
        }
        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {               
                return true;
            }
            return false;
        }
    }
}
