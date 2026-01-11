using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    public GameObject doorObject; // The actual door that appears
    public GameObject findTheDoorText; // Hint text when door appears
    public GameObject goInThereText; // Prompt to enter door
    private bool isOpen = false; // Track if door has been opened

    void Update() // To check if player has enough keys to open door
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int requiredKeys; // Each level needs different key counts
        
        if (sceneName == "Level 2")
            requiredKeys = 3; // Level 2 needs 3 keys
        else if (sceneName == "Level 3")
            return; // Level 3 uses Level3UnlockDoor system, skip this logic
        else
            requiredKeys = 2; // Default: 2 keys
        
        if (!isOpen && PlayerMovement.totalKeyCount == requiredKeys) // Open door when player has enough keys
        {
            doorObject.SetActive(true); // Make door visible
            if (findTheDoorText != null)
                findTheDoorText.SetActive(true); // Show hint text
            if (goInThereText != null)
                goInThereText.SetActive(true); // Show enter prompt
            isOpen = true; // Mark door as opened
        }
    }

    void OnTriggerEnter(Collider other) // Is called when player touches door collider
    {
        if (other.CompareTag("Player") && isOpen) // Only work if player touches opened door
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "Level 3" && PlayerMovement.totalKeyCount == 3)
            {
                SceneManager.LoadScene("GameWin"); // Load victory screen
            }
            else if (sceneName == "Level 2" && PlayerMovement.totalKeyCount == 3)
            {
                SceneManager.LoadScene("Level 3"); // Go to next level
            }
            else
            {
                SceneManager.LoadScene("Level 2"); // Default next level
            }
        }
    }
}
