using MediatR;
using Microsoft.Extensions.Options;
using SensitiveData.CTF.TokenizerAPI.Domain;
using SensitiveData.CTF.TokenizerAPI.Infrastructure;

namespace SensitiveData.CTF.TokenizerAPI.App
{
    public class CaptureCardCommand : CardDomain, IRequest<TokenDomain>
    {
    }

    public class CaptureCardCommandHandler : IRequestHandler<CaptureCardCommand, TokenDomain>
    {
        private IHttpWrapper _httpClient;
        private ApiConfiguration _configuration;

        public CaptureCardCommandHandler(IHttpWrapper httpClient, IOptions<ApiConfiguration> configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration.Value;
        }

        public async Task<TokenDomain> Handle(CaptureCardCommand request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_configuration.BrownBoxEncryptUrl + "/api/card", request);
            return new TokenDomain(await response.Content.ReadAsStringAsync());
        }
    }
}
