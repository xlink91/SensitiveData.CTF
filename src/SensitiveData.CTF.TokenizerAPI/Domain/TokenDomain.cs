namespace SensitiveData.CTF.TokenizerAPI.Domain
{
    public class TokenDomain
    {
        public TokenDomain(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
