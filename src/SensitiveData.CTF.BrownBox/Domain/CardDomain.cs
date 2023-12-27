namespace SensitiveData.CTF.BrownBox.Domain
{
    public class CardDomain
    {
        public PanDomain Pan { get; set; }
        public CvvDomain Cvv { get; set; }
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
    public class CardOwnerDomain
    {
        public string Name { get; set; }
    }
}
