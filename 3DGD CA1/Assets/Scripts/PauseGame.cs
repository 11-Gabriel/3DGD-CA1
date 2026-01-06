using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu; 
    public Button resumeGameButton; 
    public Button mainMenuButton; 
    
    private bool isPaused = false; // Track if game is currently paused

    void Start() // Set up button click listeners
    {
        resumeGameButton.onClick.AddListener(ResumeGame); // Call ResumeGame when resume button clicked
        mainMenuButton.onClick.AddListener(LoadMainMenu); // Call LoadMainMenu when menu button clicked
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // When player pressed Escape key
        {
            if (isPaused)
                ResumeGame(); // Unpause if already paused
            else
                PauseGameFunction(); // Pause if not paused
        }
    }
    
    public void PauseGameFunction() // Stop game and show pause menu
    {
        PauseMenu.SetActive(true); // Show pause menu UI
        Time.timeScale = 0f; // Freeze all game time
        isPaused = true; // Mark game as paused
    }
    
    public void ResumeGame() // Resume game and hide pause menu
    {
        PauseMenu.SetActive(false); // Hide pause menu UI
        Time.timeScale = 1f; // Restore normal game speed
        isPaused = false; // Mark game as not paused
    }
    
    public void LoadMainMenu() // Return to main menu screen
    {
        Time.timeScale = 1f; // Restore normal time before leaving scene
        SceneManager.LoadScene("MainMenuScene"); // Load main menu scene
    }
}
