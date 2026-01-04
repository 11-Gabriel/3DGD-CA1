using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    private float timeLeft;
    
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level 2")
            timeLeft = 60f;
        else if (sceneName == "Level 3")
            timeLeft = 45f;
        else
            timeLeft = 90f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if (timeLeft >= 60)
        {
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.CeilToInt(timeLeft % 60);
            Timer.text = "Time: " + minutes + " Minute " + seconds + " seconds";
        }
        else
        {
            Timer.text = "Time: " + Mathf.Ceil(timeLeft) + " seconds";
        }
        
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
