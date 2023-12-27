using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveData.CTF.BrownBox.Domain;
using System.Net;

namespace SensitiveData.CTF.BrownBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenRepository _tokenRepository;

        public TokenController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        [HttpGet("{token}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<TokenizedCardDomain>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string token)
        {
            return Ok(_tokenRepository.Get(TokenDomain.Create(token)));
        }
    }
}
