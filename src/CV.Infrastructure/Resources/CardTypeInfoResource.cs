namespace CV.Infrastructure.Resources
{
    public class CardTypeInfo
    {
        public string RegEx { get; set; }
        public int Length { get; set; }
        public CardType Type { get; set; }

        public CardTypeInfo(string regEx, int length, CardType type)
        {
            RegEx = regEx;
            Length = length;
            Type = type;
        }
    }

    public enum CardType
    {
        Unknown,
        Visa,
        MasterCard,
        Amex,
        JCB
    }
}
