using NUnit.Framework;
using UnityEngine;

public class SceneTests
{
    [Test]
    public void CanPlayerGetThroughDoor()
    {
        // Arrange
        Player player = Object.FindObjectOfType<Player>();
        Door door = Object.FindObjectOfType<Door>();

        // Ensure player and door are found
        Assert.IsNotNull(player, "Player not found in scene");
        Assert.IsNotNull(door, "Door not found in scene");

        // Act
        var items = GameObject.FindObjectsOfType<Item>();
        foreach (var item in items)
        {
            player.AddScore(item.Score);
        }

        // Assert
        bool canOpenDoor = player.Score >= door.Score;
        Assert.IsTrue(canOpenDoor, "Player cannot get through the door with the current items and score");
    }

    [Test]
    // Can player get through level
    public void CanPlayer_CompleteLevel()
    {
        // Arrange
        Player player = Object.FindObjectOfType<Player>();
        Door door = Object.FindObjectOfType<Door>();
        Level level = Object.FindObjectOfType<Level>();

        // Ensure entities are found
        Assert.IsNotNull(player, "Player not found in scene");
        Assert.IsNotNull(door, "Door not found in scene");
        Assert.IsNotNull(level, "Level not found in scene");

        // Assert
        var items = Object.FindObjectsOfType<Item>();
        foreach (var item in items)
        {
            player.AddScore(item.Score);
        }

        player.SubtractScore(door.Score);

        // Act
        var canOpenDoor = player.Score >= 0;
        Assert.IsTrue(canOpenDoor, "Items Allocated Score cannot open door");
    }
}