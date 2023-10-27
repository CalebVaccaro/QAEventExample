using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score => score;
    [SerializeField] private TMP_Text scoreText;

    public void Start()
    {
        SetScoreText(score);
    }

    public void AddScore(int newScore)
    {
        score = score.AddScore(newScore);
        SetScoreText(score);
    }

    public void SubtractScore(int newScore)
    {
        score = score.SubtractScore(newScore);
        SetScoreText(score);
    }

    private void SetScoreText(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = string.Format("{0}: {1}", "Score", score.ToString());
        }
    }
}