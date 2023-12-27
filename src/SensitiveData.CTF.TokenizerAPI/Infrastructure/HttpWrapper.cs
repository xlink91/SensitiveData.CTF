namespace SensitiveData.CTF.TokenizerAPI.Infrastructure
{
    public interface IHttpWrapper
    {
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data);
    }
    public class HttpWrapper : IHttpWrapper
    {
        private static readonly HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            return await _client.PostAsJsonAsync(url, data);
        }
    }
}
