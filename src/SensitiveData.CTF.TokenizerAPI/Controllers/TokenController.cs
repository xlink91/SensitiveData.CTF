using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SensitiveData.CTF.TokenizerAPI.Infrastructure;

namespace SensitiveData.CTF.TokenizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ApiConfiguration _config;
        private IHttpWrapper _httpClient;

        public TokenController(IHttpWrapper httpClient, IOptions<ApiConfiguration> config)
        {
            _config = config.Value;
            _httpClient = httpClient;
        }

        [HttpGet("{token}")]
        public async Task<IActionResult> GetAsync(string token)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_config.BrownBoxEncryptUrl + "/api/token/" + token);
            return Ok(await response.Content.ReadFromJsonAsync<dynamic>());
        }
    }
}
