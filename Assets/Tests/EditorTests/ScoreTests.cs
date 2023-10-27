using NUnit.Framework;
using UnityEngine;

public class ScoreTests
{
    [Test]
    public void AddScore()
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var y = 2;
        var shouldBeValue = 2;

        // Act
        player.AddScore(y);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void AddItemScoreToPlayer()
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var item = CreateTestObject<Item>("Item");
        var shouldBeValue = 10;

        // Act
        var itemScore = MathExtensions.AddScore(item.Score, 10);
        player.AddScore(itemScore);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void PlayerScore_EqualToDoor()
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var door = CreateTestObject<Door>("Door");
        var shouldBeValue = true;

        // Act
        var playerScore = MathExtensions.AddScore(player.Score, 10);
        var doorScore = MathExtensions.AddScore(door.Score, 10);
        var outcome = doorScore.IsSameScore(playerScore);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    [Test]
    [TestCase(10, 10, true)]
    [TestCase(15, 10, false)]
    [TestCase(0, 0, true)]
    [TestCase(20, 10, false)]
    public void PlayerScore_EqualToDoor(int playerScoreToAdd, int doorScoreRequired, bool expectedOutcome)
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var door = CreateTestObject<Door>("Door");
        var shouldBeValue = expectedOutcome;

        // Act
        var playerScore = MathExtensions.AddScore(player.Score, playerScoreToAdd);
        var doorScore = MathExtensions.AddScore(door.Score, doorScoreRequired);
        var outcome = doorScore.IsSameScore(playerScore);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    // Can Complete Level with Doors and Items in Scene
    [Test]
    public void SubtractScore()
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var y = 10;
        var shouldBeValue = -10;

        // Act
        player.SubtractScore(y);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }

    [Test]
    public void SubtractMultipleDoors_FromPlayer()
    {
        // Arrange
        var player = CreateTestObject<Player>("Player");
        var door1 = CreateTestObject<Door>("Door1");
        var door2 = CreateTestObject<Door>("Door2");
        var outcomeScore = 10;

        // Act
        player.AddScore(100);
        var door1Score = door1.Score.AddScore(60);
        var door2Score = door2.Score.AddScore(30);
        player.SubtractScore(door1Score);
        player.SubtractScore(door2Score);

        // Assert
        Assert.AreEqual(outcomeScore, player.Score);
    }

    public static T CreateTestObject<T>(string name) where T : Component
    {
        var gameObject = new GameObject(name);
        return gameObject.AddComponent<T>();
    }
}