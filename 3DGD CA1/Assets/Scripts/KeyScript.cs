using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject floatingText;
    [SerializeField] private bool onlyInLevel1 = true;
    
    void Start()
    {
        if (onlyInLevel1 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level 1")
        {
            if (floatingText != null)
                floatingText.SetActive(false);
        }
    }
    
    void OnDestroy()
    {
        if (!onlyInLevel1 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 1")
        {
            if (floatingText != null)
                floatingText.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyKeyAndFloatingText();
        }
    }
    
    public void DestroyKeyAndFloatingText()
    {
        if (!onlyInLevel1 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 1")
        {
            if (floatingText != null)
                floatingText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
