using NUnit.Framework;

public class MathExtensionsTests
{
    [Test]
    public void AddScore()
    {
        // Arrange
        var x = 4;
        var y = 5;
        var shouldBeValue = 9;

        // Act
        var outcome = MathExtensions.AddScore(x, y);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    [Test]
    public void AreScoresEqual()
    {
        //Arrange
        var x = 100;
        var y = 100;
        var shouldBeValue = true;

        // Act
        var outcome = MathExtensions.IsSameScore(x, y);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }

    [Test]
    public void SubtractScore()
    {
        // Arrange
        var x = 10;
        var y = 5;
        var shouldBeValue = 5;

        // Act
        var outcome = MathExtensions.SubtractScore(x, y);

        // Assert
        Assert.AreEqual(shouldBeValue, outcome);
    }
}
