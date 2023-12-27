namespace SensitiveData.CTF.TokenizerAPI.Domain
{
    public class CardDomain
    {
        public EmailDomain Email { get; set; }
        public PanDomain Pan { get; set; }
        public CvvDomain Cvv { get; set; }
        public ExpirationDateDomain Expiration { get; set; }
        public CardOwnerDomain CardOwner { get; set; }
    }

    public class PanDomain
    {
        public string Value { get; set; }
    }
    public class CvvDomain
    {
        public string Value { get; set; }
    }
    public class EmailDomain
    {
        public string Value { get; set; }
    }
    public class ExpirationDateDomain
    {
        public string Value { get; set; }
    }
    public class CardOwnerDomain
    {
        public string Name { get; set; }
    }
}
