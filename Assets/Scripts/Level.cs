using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public UnityEvent onCompleteLevel;

    public void Start()
    {
        onCompleteLevel.AddListener(() => EndLevel());
    }

    private void EndLevel()
    {
        Debug.Log("Level Complete");
        ReloadScene();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            onCompleteLevel.Invoke();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
