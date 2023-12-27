using MediatR;
using SensitiveData.CTF.BrownBox.Domain;

namespace SensitiveData.CTF.BrownBox.App
{
    public class TokenizeCardCommand : CardDomain, IRequest<string>
    {
    }
    public class TokenizeCardCommandHandler : IRequestHandler<TokenizeCardCommand, string>
    {
        private ITokenizer _tokenizer;
        public TokenizeCardCommandHandler(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        public Task<string> Handle(TokenizeCardCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tokenizer.Tokenize(request));
        }
    }
}
