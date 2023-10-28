<img src="SampleScene-PlayMode.png" width="300" />

# Sample Scene - Play Mode Unit Testing: Player and Item Collision

Welcome to Scene 1, where we delve into play mode unit testing in Unity, focusing on interactions between the player and an item.

## Overview

In this scene, a `Player` object interacts with an `Item` object, and we will test whether the player's score increases correctly upon collision.

## Play Mode Tests

Play mode tests in Unity allow us to verify game behavior during runtime, which is crucial for interactions, animations, and other dynamic behaviors.

## The Test: `PlayerCollideWithItem_IncreaseScore`

Our objective is to ensure that the player's score increases correctly upon colliding with the item.

### Steps:

1. **Arrange**:
   ```csharp
   var player = GameObject.Find("Player").GetComponent<Player>();
   var item = GameObject.Find("Item").GetComponent<Item>();
   var shouldBeValue = 1;

   Assert.IsNotNull(player, "Player not found");
   Assert.IsNotNull(item, "Item not found");
   ```
   First, find and store references to the `Player` and `Item` objects. Set an expected score value for the player after the collision, and ensure both objects are present in the scene.

2. **Act**:
   ```csharp
   player.transform.position = item.transform.position;
   yield return new WaitForSeconds(1);
   ```
   Move the player to the item's position to trigger a collision, then wait to ensure the game's physics engine has time to process the interaction.

3. **Assert**:
   ```csharp
   Assert.AreEqual(shouldBeValue, player.Score);
   ```
   Verify that the player's score after the collision matches the expected value, confirming the score increases correctly.

### How to Run

Navigate to Unity's Test Runner, select play mode testing, and run the `PlayerCollideWithItem_IncreaseScore` test.

## Conclusion

This guide provides insights into setting up and executing play mode tests in Unity, ensuring your game mechanics behave as intended during runtime.
