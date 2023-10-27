using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score => score;

    // Validate if We Collided With Player
    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            player.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}
