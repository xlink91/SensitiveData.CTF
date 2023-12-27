using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveData.CTF.TokenizerAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace SensitiveData.CTF.TokenizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptureController : ControllerBase
    {
        [HttpPost] 
        public async Task<IActionResult> Post(CardDomain card)
        {
            throw new NotImplementedException();
        }
    }
}
