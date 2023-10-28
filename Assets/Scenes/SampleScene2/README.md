<img src="SampleScene2.png" width="300"/>

# Testing Player-Item Interaction and Door Accessibility

## Overview
In this sample scene, we'll focus on creating a basic unit test to validate the player's ability to collect items, accumulate score, and subsequently access a door.

## Creating the Method
In this section, we will be creating a unit test method to check if the player can get through the door based on the items collected in the scene.

- Arrange: Retrieve the player and door objects from the scene, ensuring they are present.

```csharp
Player player = Object.FindObjectOfType<Player>();
Door door = Object.FindObjectOfType<Door>();

// Make sure we have a Player and a Door
Assert.IsNotNull(player, "Player not found in scene");
Assert.IsNotNull(door, "Door not found in scene");
```

- Act: Find all items in the scene, add their scores to the player's score, and then check if the player's score allows them to open the door.
```csharp
Item[] items = GameObject.FindObjectsOfType<Item>();
foreach (var item in items)
{
    player.AddScore(item.Score);
}
bool canOpenDoor = player.Score == door.Score;
```

Assert: Ensure that the player can open the door with the current score.
```csharp
Assert.IsTrue(canOpenDoor, "Player cannot get through the door with the current items and score");
```