using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject findTheDoorText;
    public GameObject goInThereText;
    private bool isOpen = false;

    void Update()
    {
        bool isLevel2 = SceneManager.GetActiveScene().name == "Level 2";
        int requiredKeys = isLevel2 ? 3 : 2;
        
        if (!isOpen && PlayerMovement.totalKeyCount == requiredKeys)
        {
            doorObject.SetActive(true);
            if (findTheDoorText != null)
                findTheDoorText.SetActive(true);
            if (goInThereText != null)
                goInThereText.SetActive(true);
            isOpen = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            bool isLevel2 = SceneManager.GetActiveScene().name == "Level 2";
            if (isLevel2 && PlayerMovement.totalKeyCount == 3)
            {
                SceneManager.LoadScene("Level 3");
            }
            else
            {
                SceneManager.LoadScene("Level 2");
            }
        }
    }
}
