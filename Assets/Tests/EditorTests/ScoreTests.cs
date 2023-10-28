using NUnit.Framework;
using UnityEngine;

public class ScoreTests
{
    [Test]
    public void AddScore()
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        int y = 2;
        int shouldBeValue = 2;

        // Act
        player.AddScore(y);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void AddItemScoreToPlayer()
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        Item item = CreateTestObject<Item>("Item");
        int shouldBeValue = 10;

        // Act
        int itemScore = MathExtensions.AddScore(item.Score, 10);
        player.AddScore(itemScore);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void PlayerScore_EqualToDoor()
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        Door door = CreateTestObject<Door>("Door");
        bool shouldBeValue = true;

        // Act
        int playerScore = MathExtensions.AddScore(player.Score, 10);
        int doorScore = MathExtensions.AddScore(door.Score, 10);
        bool outcome = doorScore.IsSameScore(playerScore);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    [Test]
    [TestCase(10, 10, true)]
    public void PlayerScore_EqualToDoor(int playerScoreToAdd, int doorScoreRequired, bool expectedOutcome)
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        Door door = CreateTestObject<Door>("Door");
        bool shouldBeValue = expectedOutcome;

        // Act
        int playerScore = MathExtensions.AddScore(player.Score, playerScoreToAdd);
        int doorScore = MathExtensions.AddScore(door.Score, doorScoreRequired);
        bool outcome = doorScore.IsSameScore(playerScore);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    // Can Complete Level with Doors and Items in Scene
    [Test]
    public void SubtractScore()
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        int y = 10;
        int shouldBeValue = -10;

        // Act
        player.SubtractScore(y);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void SubtractMultipleDoors_FromPlayer()
    {
        // Arrange
        Player player = CreateTestObject<Player>("Player");
        Door door1 = CreateTestObject<Door>("Door1");
        Door door2 = CreateTestObject<Door>("Door2");
        int outcomeScore = 10;

        // Act
        player.AddScore(100);
        int door1Score = MathExtensions.AddScore(door1.Score, 60);
        int door2Score = MathExtensions.AddScore(door2.Score, 30);
        player.SubtractScore(door1Score);
        player.SubtractScore(door2Score);

        // Assert
        Assert.AreEqual(outcomeScore, player.Score);
    }

    public static T CreateTestObject<T>(string name) where T : Component
    {
        GameObject gameObject = new GameObject(name);
        return gameObject.AddComponent<T>();
    }
}