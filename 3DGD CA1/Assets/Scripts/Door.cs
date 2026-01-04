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
        string sceneName = SceneManager.GetActiveScene().name;
        int requiredKeys;
        
        if (sceneName == "Level 2")
            requiredKeys = 3;
        else if (sceneName == "Level 3")
            requiredKeys = 3;
        else
            requiredKeys = 2;
        
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
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "Level 3" && PlayerMovement.totalKeyCount == 3)
            {
                SceneManager.LoadScene("GameWin");
            }
            else if (sceneName == "Level 2" && PlayerMovement.totalKeyCount == 3)
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
