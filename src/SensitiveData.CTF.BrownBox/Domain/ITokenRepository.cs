namespace SensitiveData.CTF.BrownBox.Domain
{
    public interface ITokenRepository
    {
        IReadOnlyCollection<TokenizedCardDomain> Get(TokenDomain token);
    }
}
