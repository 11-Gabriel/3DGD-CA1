using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject doorObject;
    private bool isOpen = false;

    void Update()
    {
        if (!isOpen && PlayerMovement.totalKeyCount == 2)
        {
            doorObject.SetActive(true);
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
