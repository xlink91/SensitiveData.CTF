using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensitiveData.CTF.BrownBox.App;

namespace SensitiveData.CTF.BrownBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private IMediator _mediator;
        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<string> Tokenize(TokenizeCardCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
