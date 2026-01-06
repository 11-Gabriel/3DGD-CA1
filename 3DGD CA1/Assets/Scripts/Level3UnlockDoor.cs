using UnityEngine;
using System.Collections;

public class Level3UnlockDoor : MonoBehaviour
{
    public GameObject orangeKey; 
    public GameObject redKey; 
    public GameObject purpleKey; 
    
    public void CheckKeys() // Check if player has all three colored keys
    {
        bool hasOrangeKey = orangeKey == null; // Orange key is null means it was collected
        bool hasRedKey = redKey == null; // Red key is null means it was collected
        bool hasPurpleKey = purpleKey == null; // Purple key is null means it was collected
        
        if (hasOrangeKey && hasRedKey && hasPurpleKey) 
        {
            StartCoroutine(DestroyDoorAfterDelay()); // Open the door if player has all keys
        }
    }
    
    IEnumerator DestroyDoorAfterDelay() // Destroy door after short delay
    {
        yield return new WaitForSeconds(0.1f); // Wait 0.1 seconds before destroying
        Destroy(gameObject); // Remove door from game
    }
    
    void OnTriggerEnter(Collider other) // Called when player touches door
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            CheckKeys(); // See if player can unlock this door
        }
    }
}
