using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private static float totalTime = 0f;
    private static bool isTracking = false;
    
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        if (sceneName == "MainMenu")
        {
            isTracking = false;
        }
        else if (sceneName == "GameOverScene")
        {
            isTracking = false;
        }
        else if (sceneName == "Level 1")
        {
            totalTime = 0f;
            isTracking = true;
        }
        
        if (sceneName == "GameWin")
        {
            isTracking = false;
            if (timeText != null)
            {
                timeText.text = "Time Taken: " + FormatTime(totalTime);
            }
        }
    }
    
    void Update()
    {
        if (isTracking)
        {
            totalTime += Time.deltaTime;
        }
    }
    
    string FormatTime(float time)
    {
        if (time >= 60)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.CeilToInt(time % 60);
            return minutes + " Minute " + seconds + " seconds";
        }
        else
        {
            return Mathf.Ceil(time) + " seconds";
        }
    }
}
