using SnapGame;
using MatchType = SnapGame.MatchType;

namespace SanpGameUnitTests
{
    public class PlaySnapGame_UnitTests
    {
        [Fact]
        public void PlayGame_SnapOnValueMatch_UpdatesPlayerScore()
        {
            // Arrange: Create a deck with a value match (two "5"s in a row)
            var deck = new List<Card>
            {
                new Card("5", "Hearts"),
                new Card("5", "Clubs"), // This should trigger a snap on value
                new Card("7", "Diamonds")
            };

            // Act
            var result = PlaySnapGame.PlayGame(deck, MatchType.Value);

            // Assert
            // The pile will have 2 cards when the snap occurs, and one player will get 2 points.
            int totalScore = result.PlayerScores[1] + result.PlayerScores[2];
            Assert.Equal(2, totalScore);
            Assert.True(result.PlayerScores[1] == 2 || result.PlayerScores[2] == 2);
        }

        [Fact]
        public void PlayGame_SnapOnSuitMatch_UpdatesPlayerScore()
        {
            // Arrange: Create a deck with a value match (two "5"s in a row)
            var deck = new List<Card>
            {
                new Card("5", "Hearts"),
                new Card("6", "Clubs"), 
                new Card("7", "Clubs"),// This should trigger a snap on value
                new Card("8", "Hearts")
            };

            // Act
            var result = PlaySnapGame.PlayGame(deck, MatchType.Suit);

            // Assert
            // The pile will have 2 cards when the snap occurs, and one player will get 3 points.
            int totalScore = result.PlayerScores[1] + result.PlayerScores[2];
            Assert.Equal(3, totalScore);
        }

        [Fact]
        public void PlayGame_SnapOnSuitAndValueMatch_UpdatesPlayerScore()
        {
            // Arrange: Create a deck with a value match (two "5"s in a row)
            var deck = new List<Card>
            {
                new Card("5", "Hearts"),
                new Card("6", "Clubs"),
                new Card("6", "Clubs"),// This should trigger a snap on value
                new Card("7", "Hearts")
            };

            // Act
            var result = PlaySnapGame.PlayGame(deck, MatchType.Both);

            // Assert
            // The pile will have 2 cards when the snap occurs, and one player will get 3 points.
            int totalScore = result.PlayerScores[1] + result.PlayerScores[2];
            Assert.Equal(3, totalScore);
        }
    }
}
