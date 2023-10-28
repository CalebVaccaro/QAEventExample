<img src="SampleScene4.png" width="300"/>

# Debugging and Resolving Unit Test Failures

## Introduction
In this example, we have a Unity scene set up with a player, a door, and several items. A unit test is in place to ensure that the player can collect enough items to open the door. However, the test is currently failing because there are not enough items in the scene. Your task is to add more items to the scene so that the unit test passes.

## Identifying the Issue
The unit test designed to validate the player's ability to open the door is failing. This indicates that the total score from the items currently in the scene is not enough to meet the door's required score.

## Adding Items to Pass the Test
To resolve this issue, you need to:

1. Check the unit test’s failure message, which should give you information on the expected outcome and what is currently happening.
2. Calculate how many more points are needed for the player to be able to open the door.
3. Add the required number of items to the scene, ensuring their total score meets or exceeds the door's score requirement.

## Verifying the Solution
Once you have added enough items to the scene:

1. Re-run the unit tests.
2. Check that the test which was previously failing now passes. This confirms that the player can now collect enough points to open the door.
