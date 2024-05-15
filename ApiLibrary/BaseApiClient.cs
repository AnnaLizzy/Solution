using ApiLibrary.Constants;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApplicationAPI.Constants;
namespace ApiLibrary
{
    public class BaseApiClient(HttpClient httpClient, IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _baseUrl = SystemConstants.Url.BaseApiUrl;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        /// <summary>
        /// Get Data From API array object json 
        /// Data is like this: [{a:"a",b:"b"}]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// Data is list object json like {a:"a",b:"b"}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<T>?> GetAsyncList<T>(string url)
        {

            _httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(data) ?? throw new Exception("Error");
            }
            return default;
        }

        public async Task<T?> GetAsyncToken<T>(string url, string token)
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            var httpContent = new StringContent(json, Encoding.UTF8, SystemApiConst.Setting.StringContent);
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
