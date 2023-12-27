namespace SensitiveData.CTF.BrownBox.Domain
{
    public class TokenDomain
    {
        public TokenDomain(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public static TokenDomain Create(string value)
        {
            return new TokenDomain(value);
        }
    }
}
