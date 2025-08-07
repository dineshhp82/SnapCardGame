namespace SnapGame
{
    public static class Deck
    {
        static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" }; //4
        static readonly string[] Values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; //13

        public static IEnumerable<Card> CreateShuffleDeck(int nPacks) => Enumerable.Range(0, nPacks)
                .SelectMany(r => SinglePack())
                .OrderBy(x => new Random().Next());

        private static IEnumerable<Card> SinglePack()
        {
            return from suit in Suits
                   from value in Values
                   select new Card(value, suit);
        }
    }
}
