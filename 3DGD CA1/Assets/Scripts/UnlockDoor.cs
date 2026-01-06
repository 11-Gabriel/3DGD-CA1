using UnityEngine;
using TMPro;
using System.Collections;

public class UnlockDoor : MonoBehaviour
{
    public GameObject yellowKey; 
    public GameObject blueKey; 
    public GameObject findTheOtherKeyText; 
    public GameObject findTheKeysText; 
    
    void Start() // Hide hint texts at game start
    {
        if (findTheOtherKeyText != null)
            findTheOtherKeyText.SetActive(false);
        if (findTheKeysText != null)
            findTheKeysText.SetActive(false);
    }
    
    public void CheckKeys() // Check if player has collected required keys
    {
        bool hasYellowKey = yellowKey == null; // Yellow Key is null means it was collected
        bool hasBlueKey = blueKey == null; // Blue Key is null means it was collected
        
        Debug.Log("Yellow Key is null: " + hasYellowKey + ", Blue Key is null: " + hasBlueKey); // For debugging
        
        if (hasYellowKey && hasBlueKey) // Player has both keys
        {
            Debug.Log("Both keys collected - destroying door");
            StartCoroutine(DestroyDoorAfterDelay());
        }
        else if (hasYellowKey || hasBlueKey) // Player has one key
        {
            if (findTheOtherKeyText != null)
            {
                StartCoroutine(ShowTextTemporarily(findTheOtherKeyText));
            }
        }
        else  // Player has no keys
        {
            if (findTheKeysText != null)
            {
                StartCoroutine(ShowTextTemporarily(findTheKeysText));
            }
        }
    }
    
    IEnumerator DestroyDoorAfterDelay() // Destroy door after short delay
    {
        yield return new WaitForSeconds(0.1f); // Wait 0.1 seconds before destroying
        Destroy(gameObject); // Remove door from game
    }
    
    IEnumerator ShowTextTemporarily(GameObject textObject) // Show text for 1.5 seconds
    {
        textObject.SetActive(true); // Show the text
        yield return new WaitForSeconds(1.5f); // Wait 1.5 seconds
        textObject.SetActive(false); // Hide the text
    }
    
    void OnTriggerEnter(Collider other) // Called when player touches door
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            CheckKeys();
        }
    }
}
