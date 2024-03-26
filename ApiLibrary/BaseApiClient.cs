using Newtonsoft.Json;
using System.Text;
using WebApplicationAPI.Constants;
namespace ApiLibrary
{
    public class BaseApiClient(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _baseUrl = SystemConstants.Url.BaseUrl;
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
            _httpClient.BaseAddress = new Uri(_baseUrl);
            var data = JsonConvert.SerializeObject(obj);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
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
            var content = new StringContent(data, Encoding.UTF8, "application/json");
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
