using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timeText; // UI element to display time
    private static float totalTime = 0f; // Persistent across scenes
    private static bool isTracking = false; // Control when timer runs
    
    void Start() // Initialize tracking based on current scene
    {
        string sceneName = SceneManager.GetActiveScene().name; // Get current scene name
        
        if (sceneName == "MainMenu")
        {
            isTracking = false; // Don't track time in main menu
        }
        else if (sceneName == "GameOverScene")
        {
            isTracking = false; // Stop tracking time when in game over scene
        }
        else if (sceneName == "Level 1")
        {
            totalTime = 0f; // Reset timer for new game
            isTracking = true; // Start tracking time
        }
        
        if (sceneName == "GameWin")
        {
            isTracking = false; // Stop tracking when player wins
            if (timeText != null)
            {
                timeText.text = "Time Taken: " + FormatTime(totalTime); // Display final time
            }
        }
    }
    
    void Update() // Increment total time while tracking is enabled
    {
        if (isTracking) // Only add time when game is active
        {
            totalTime += Time.deltaTime; // Accumulate time
        }
    }
    
    string FormatTime(float time) // Convert time to readable string format
    {
        if (time >= 60) // If time is 1 minute or more
        {
            int minutes = Mathf.FloorToInt(time / 60); // Get whole minutes
            int seconds = Mathf.CeilToInt(time % 60); // Round up for remaining seconds
            return minutes + " Minute " + seconds + " seconds";
        }
        else // Less than 1 minute
        {
            return Mathf.Ceil(time) + " seconds"; // Round up to nearest second
        }
    }
}
