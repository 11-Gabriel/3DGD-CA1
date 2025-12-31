using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float turnSpeed = 180f;
    public float backSpeed = 2.5f;
    
    public static int totalKeyCount = 0;
    public GameObject completeText;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        float moveSpeed = Input.GetKey(KeyCode.S) ? backSpeed : speed;
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        controller.Move(move);
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Key"))
        {
            totalKeyCount++;
            Destroy(hit.collider.gameObject);
            
            if (totalKeyCount == 2)
            {
                StartCoroutine(ShowCompleteText());
            }
        }
    }
    
    System.Collections.IEnumerator ShowCompleteText()
    {
        TextMeshProUGUI text = completeText.GetComponent<TextMeshProUGUI>();
        completeText.SetActive(true);
        
        Color c = text.color;
        float alpha = 0;
        float pos = -200;
        float targetPos = 400; // Top middle position (higher)
        
        // Move to target position while fading in
        while (pos < targetPos || alpha < 1)
        {
            // Movement
            if (pos < targetPos)
            {
                pos += Time.deltaTime * 1000;
                pos = Mathf.Min(pos, targetPos);
            }
            
            // Fade
            if (alpha < 1)
            {
                alpha += Time.deltaTime * 0.5f;
                alpha = Mathf.Min(alpha, 1);
            }
            
            text.color = new Color(c.r, c.g, c.b, alpha);
            text.transform.localPosition = new Vector3(0, pos, 0);
            yield return null;
        }
        
        yield return new WaitForSeconds(5);
        
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * 0.5f;
            text.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        
        completeText.SetActive(false);
    }
}
