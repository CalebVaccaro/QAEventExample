using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Door : MonoBehaviour
{
    public int Score => score;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent openDoorEvent;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject doorObject;

    private void Start()
    {
        SetScoreText(score);
        openDoorEvent.AddListener(() => OpenDoor());
    }

    private void OpenDoor()
    {
        doorObject.SetActive(false);
        Debug.Log("Open Door");
    }

    // Validate if We Collided With Player
    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            if (IsScoreSameAsPlayer(player.Score))
            {
                player.SubtractScore(score);
                openDoorEvent.Invoke();
            }
        }
    }

    private bool IsScoreSameAsPlayer(int playerScore)
    {
        return score.IsSameScore(playerScore);
    }

    private void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
