namespace SnapGame
{
    public class Card(string value, string suit)
    {
        public string Value { get; set; } = value;
        public string Suit { get; set; } = suit;

        public override string ToString() => $"{Value} of {Suit}";

        public bool IsMatch(Card other, MatchType matchType)
        {
            return matchType switch
            {
                MatchType.Value => Value == other.Value,
                MatchType.Suit => Suit == other.Suit,
                MatchType.Both => Value == other.Value && Suit == other.Suit,
                _ => false
            };
        }
    }
}
