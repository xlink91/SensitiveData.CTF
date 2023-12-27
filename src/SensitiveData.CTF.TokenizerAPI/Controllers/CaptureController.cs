using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveData.CTF.TokenizerAPI.App;
using SensitiveData.CTF.TokenizerAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace SensitiveData.CTF.TokenizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptureController : ControllerBase
    {
        private IMediator _mediator;

        public CaptureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost] 
        public async Task<IActionResult> Post(CaptureCardCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
