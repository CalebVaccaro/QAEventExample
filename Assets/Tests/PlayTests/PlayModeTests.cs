using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayModeTests
{
    [UnitySetUp]
    public IEnumerator SetUpScene()
    {
        yield return SceneManager.LoadSceneAsync("SampleScene-PlayMode");
        yield return null;  // Ensure all scene objects are fully loaded
    }

    [UnityTest]
    public IEnumerator PlayerCollideWithItem_IncreaseScore()
    {
        // Arrange
        var player = GameObject.Find("Player").GetComponent<Player>();
        var item = GameObject.Find("Item").GetComponent<Item>();
        var shouldBeValue = 1;

        // Ensure the player and item were found
        Assert.IsNotNull(player, "Player not found");
        Assert.IsNotNull(item, "Item not found");

        // Move player to item position
        player.transform.position = item.transform.position;

        // Act
        yield return new WaitForSeconds(1);

        // Assert
        Assert.AreEqual(shouldBeValue, player.Score);
    }
}
