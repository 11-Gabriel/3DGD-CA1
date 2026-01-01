using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    private float timeLeft = 70f;

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
