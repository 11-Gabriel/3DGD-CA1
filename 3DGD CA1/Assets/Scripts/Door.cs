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
        if (!isOpen && PlayerMovement.totalKeyCount == 2)
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
            SceneManager.LoadScene("Level 2");
        }
    }
}
