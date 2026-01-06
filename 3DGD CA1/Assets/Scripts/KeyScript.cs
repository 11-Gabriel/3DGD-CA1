using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject floatingText; 
    [SerializeField] private bool onlyInLevel1 = true; // Control if key only works in Level 1
    
    void Start() // Hide floating text if not in Level 1
    {
        if (onlyInLevel1 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level 1") // Key should only appear in Level 1
        {
            if (floatingText != null)
                floatingText.SetActive(false); // Hide the hint text
        }
    }
    
    void OnDestroy() // Clean up floating text when key is destroyed
    {
        if (!onlyInLevel1 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 1") // Only clean up if key was active
        {
            if (floatingText != null)
                floatingText.SetActive(false); // Hide text when key disappears
        }
    }
    
    private void OnTriggerEnter(Collider other) // Called when player touches key
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            DestroyKeyAndFloatingText(); // Remove key and its text
        }
    }
    
    public void DestroyKeyAndFloatingText() // Remove key and hide its text
    {
        if (!onlyInLevel1 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 1") // Only destroy if key was active
        {
            if (floatingText != null)
                floatingText.SetActive(false); // Hide the floating text first
            Destroy(gameObject); // Then destroy the key object
        }
    }
}
