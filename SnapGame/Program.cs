namespace SnapGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Snap! Game Simulator for Two Players");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Players flip cards from a pile one at a time. " +
                "If two consecutive cards match (based on a chosen matching rule), a player shouts Snap!" +
                "and wins all the cards on the table.");
            Console.WriteLine("-----------------------------------");


            int packs = PromptInt("Enter number of packs (N): ");

            MatchType matchType = PromptMatchType();

            var deck = Deck.CreateShuffleDeck(packs).ToList();

            Console.WriteLine("\nStarting game...\n");

            var results = PlaySnapGame.PlayGame(deck, matchType);

            var scorePlayer1 = results.PlayerScores[1];
            var scorePlayer2 = results.PlayerScores[2];

            // Display results
            Console.WriteLine("\nGame Results:");
            Console.WriteLine($"Player 1 collected {scorePlayer1} cards");
            Console.WriteLine($"Player 2 collected {scorePlayer2} cards");


            if (scorePlayer1 > scorePlayer2)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (scorePlayer2 > scorePlayer1)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine("Would you like to play again? (y/n)");
            string playAgain = Console.ReadLine()?.ToLower();
            if (playAgain == "y")
            {
                Main(args); // Restart the game
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }

            Console.ReadLine();
        }


        private static int PromptInt(string prompt)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out var n) ? n : 1;
        }

        private static MatchType PromptMatchType()
        {
            Console.WriteLine("Choose matching condition:\n1 - Face Value\n2 - Suit\n3 - Both");
            return Console.ReadLine() switch
            {
                "1" => MatchType.Value,
                "2" => MatchType.Suit,
                "3" => MatchType.Both,
                _ => MatchType.Value
            };
        }
    }
}
