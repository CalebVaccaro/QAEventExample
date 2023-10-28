using NUnit.Framework;

public class MathExtensionsTests
{
    [Test]
    public void AddScore()
    {
        // Arrange
        int x = 4;
        int y = 5;
        int shouldBeValue = 9;

        // Act
        int outcome = MathExtensions.AddScore(x, y);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    [Test]
    public void AreScoresEqual()
    {
        //Arrange
        int x = 100;
        int y = 100;
        bool shouldBeValue = true;

        // Act
        bool outcome = MathExtensions.IsSameScore(x, y);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

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
}
