<img src="SampleScene5.png" width="300"/>

# Implementing and Testing Score Subtraction

## Introduction
This guide walks through the implementation of a score subtraction feature in a game, as well as the creation of unit tests to validate its functionality.

Score Subtraction Implementation
```csharp
public static int SubtractScore(this int score1, int score2)
{
    return score1 - score2;
}
```
Unit Tests for Score Subtraction
1. Basic Score Subtraction Test
```csharp
[Test]
public void SubtractScore()
{
    // Arrange
    int x = 10;
    int y = 5;
    int shouldBeValue = 5;

    // Act
    int outcome = MathExtensions.SubtractScore(x, y);

    // Assert
    Assert.AreEqual(shouldBeValue, outcome);
}
```
2. Subtracting from Player's Score
```csharp
[Test]
public void SubtractScore_PlayerScore()
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
```
3. Completing Level with Doors and Items
```csharp
[Test]
public void CanCompleteLevel_WithDoorsAndItems()
{
    // Arrange
    Player player = CreateTestObject<Player>("Player");
    Door door = CreateTestObject<Door>("Door");
    Item item = CreateTestObject<Item>("Item");
    item.Score = 10;
    door.ScoreCost = 5;
    int shouldBeValue = 5;

    // Act
    player.AddScore(item.Score);
    player.SubtractScore(door.ScoreCost);

    // Assert
    Assert.AreEqual(shouldBeValue, player.Score);
}
```
Conclusion
By implementing the SubtractScore feature and accompanying unit tests, we've ensured that our game's scoring mechanics work correctly, even when scores are subtracted.

