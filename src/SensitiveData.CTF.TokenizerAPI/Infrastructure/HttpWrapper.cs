namespace SensitiveData.CTF.TokenizerAPI.Infrastructure
{
    public interface IHttpWrapper
    {
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data);
        Task<HttpResponseMessage> GetAsync(string url);
    }
    public class HttpWrapper : IHttpWrapper
    {
        private static readonly HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            return await _client.PostAsJsonAsync(url, data);
        }
    }
}
