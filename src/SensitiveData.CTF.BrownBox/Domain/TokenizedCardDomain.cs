namespace SensitiveData.CTF.BrownBox.Domain
{
    public class TokenizedCardDomain
    {
        public TokenDomain Pan { get; set; }
        public CardOwnerDomain CardOwner { get; set; }
        public static TokenizedCardDomain Create(string pan, string owner)
        {
            return new TokenizedCardDomain
            {
                CardOwner = new CardOwnerDomain
                {
                    Name = owner
                },
                Pan = new TokenDomain(pan)
            };
        }
    }
}
