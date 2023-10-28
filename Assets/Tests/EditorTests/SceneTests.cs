using NUnit.Framework;
using UnityEngine;

public class SceneTests
{
    [Test]
    // Can player get through level
    public void CanPlayer_CompleteLevel()
    {
        // Arrange
        Player player = Object.FindObjectOfType<Player>();
        Level level = Object.FindObjectOfType<Level>();

        // Ensure entities are found
        Assert.IsNotNull(player, "Player not found in scene");
        Assert.IsNotNull(level, "Level not found in scene");

        // Assert
        Item[] items = Object.FindObjectsOfType<Item>();
        foreach (var item in items)
        {
            player.AddScore(item.Score);
        }

        Door[] doors = Object.FindObjectsOfType<Door>();
        Assert.IsNotNull(doors, "Doors not found in scene");
        foreach (var door in doors)
        {
            player.SubtractScore(door.Score);
        }

        // Act
        bool canOpenDoor = player.Score >= 0;
        Assert.IsTrue(canOpenDoor, "Items Allocated Score cannot open door");
    }
}