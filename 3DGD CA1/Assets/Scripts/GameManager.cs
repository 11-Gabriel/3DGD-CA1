using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Timer; 
    private float timeLeft; 
    
    void Start() // Set time limit based on current level
    {
        string sceneName = SceneManager.GetActiveScene().name; // Get current level name
        if (sceneName == "Level 2")
            timeLeft = 60f; // 1 minute for Level 2
        else if (sceneName == "Level 3")
            timeLeft = 45f; // 45 seconds for Level 3
        else
            timeLeft = 90f; // 1.5 minutes for other levels
    }

    void Update() // Update countdown timer and check game over
    {
        timeLeft -= Time.deltaTime; // Count down the time
        
        if (timeLeft >= 60) // If 1 minute or more remains
        {
            int minutes = Mathf.FloorToInt(timeLeft / 60); // Get whole minutes
            int seconds = Mathf.CeilToInt(timeLeft % 60); // Round up remaining seconds
            Timer.text = "Time: " + minutes + " Minute " + seconds + " seconds";
        }
        else // Less than 1 minute remains
        {
            Timer.text = "Time: " + Mathf.Ceil(timeLeft) + " seconds"; // Show only seconds
        }
        
        if (timeLeft <= 0) // Time's up!
        {
            SceneManager.LoadScene("GameOverScene"); // Load game over screen
        }
    }
}
