namespace SnapGame
{
    public class PlaySnapGame
    {
        private static readonly Random _random = new();

        public static GameResult PlayGame(List<Card> deck, MatchType matchType)
        {
            var playerScores = new Dictionary<int, int> { { 1, 0 }, { 2, 0 } };
            var pile = new List<Card>();// pile holds the current stack of cards in play.
            Card previousCard = null; //previousCard keeps track of the last card played.

            /*	For each card in the deck:
                 -	Add the card to the pile.
                 -	If there is a previous card and the current card matches it(according to the matchType), a "Snap" occurs:
                 -	Randomly select a winner(either player 1 or 2).
                 -	Add the number of cards in the pile to the winner's score.
                 -	Clear the pile and reset previousCard.
                 -	If no match, set previousCard to the current card for the next iteration.*/

            foreach (var card in deck)
            {
                pile.Add(card);

                if (previousCard != null && card.IsMatch(previousCard, matchType))
                {
                    //Console.WriteLine($"Previous Card {previousCard} and Current Card {card}" );
                    int winner = _random.Next(1, 3); // Randomly choose player 1 or 2
                    playerScores[winner] += pile.Count;
                    pile.Clear();
                    previousCard = null;
                }
                else
                {
                    previousCard = card;
                }
            }

            return new GameResult(playerScores);
        }
    }
}
