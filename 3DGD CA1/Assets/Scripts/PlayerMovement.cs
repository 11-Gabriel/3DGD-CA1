using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller; 
    public float speed = 5f; 
    public float turnSpeed = 180f; 
    public float backSpeed = 2.5f; 
    
    public static int totalKeyCount = 0; // Shared across all scripts
    public GameObject completeText; // Shows when level is complete

    void Start() // Initialize controller and reset key count for levels
    {
        controller = GetComponent<CharacterController>(); 
        
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName == "Level 1" || sceneName == "Level 2" || sceneName == "Level 3")
        {
            totalKeyCount = 0; // Reset keys for new level
        }
    }

    void Update() // Handle player movement and rotation based on input
    {
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Left/right input
        transform.Rotate(0, turn, 0); // Rotate player left/right

        float moveSpeed = Input.GetKey(KeyCode.S) ? backSpeed : speed; // Use slower speed when backing up
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Forward/backward input
        controller.Move(move); // Apply movement
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit) // Handle collisions with keys and doors
    {
        if (hit.collider.gameObject.CompareTag("Key")) 
        {
            totalKeyCount++; // Add to key collection
            Destroy(hit.collider.gameObject); // Remove key from scene
            
            bool isLevel3 = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 3";
            int requiredKeys = isLevel3 ? 3 : 2; // Level 3 needs 3 keys, others need 2
            
            if (totalKeyCount == requiredKeys) // Check if player collected all needed keys
            {
                StartCoroutine(ShowCompleteText()); // Show completion message
            }
        }
        else if (hit.collider.gameObject.CompareTag("Door")) // Player touched a door
        {
            UnlockDoor doorScript = hit.collider.gameObject.GetComponent<UnlockDoor>(); // Get door script for levels 1-2
            if (doorScript != null)
            {
                doorScript.CheckKeys(); // See if player can unlock this door
            }
            else
            {
                Level3UnlockDoor level3DoorScript = hit.collider.gameObject.GetComponent<Level3UnlockDoor>(); // Get door script for level 3
                if (level3DoorScript != null)
                {
                    level3DoorScript.CheckKeys(); // See if player can unlock level 3 door
                }
            }
        }
    }

    // -------------- Text animation stuff -------------- 


    // Animate completion text with fade and movement
    System.Collections.IEnumerator ShowCompleteText() 
    {
        TextMeshProUGUI text = completeText.GetComponent<TextMeshProUGUI>();
        completeText.SetActive(true);
        
        Color c = text.color; // Store original color
        float alpha = 0; // Transparency (0 = invisible, 1 = fully visible)
        float pos = -200; // Starting position (off screen)
        float targetPos = 0; // End position (center of screen)
        
        // Move to target position while fading in
        while (pos < targetPos || alpha < 1)
        {
            // Movement of the text
            if (pos < targetPos)
            {
                pos += Time.deltaTime * 1000; // Move text upward
                pos = Mathf.Min(pos, targetPos); // Don't go past target
            }
            
            // Fading alpha of the text
            if (alpha < 1)
            {
                alpha += Time.deltaTime * 0.5f; // Fade in speed
                alpha = Mathf.Min(alpha, 1); // Don't exceed fully visible
            }
            
            text.color = new Color(c.r, c.g, c.b, alpha); // Apply transparency
            text.transform.localPosition = new Vector3(0, pos, 0); // Apply position
            yield return null; // Wait for next frame
        }
        
        yield return new WaitForSeconds(1); // Show text for 1 second
        
        while (alpha > 0) // Fade out loop
        {
            alpha -= Time.deltaTime * 0.5f; // Fade out speed
            text.color = new Color(c.r, c.g, c.b, alpha); // Apply fading
            yield return null; // Wait for next frame
        }
        
        completeText.SetActive(false); // Hide text when done
    }
}
