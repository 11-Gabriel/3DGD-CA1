using UnityEngine;
using TMPro;
using System.Collections;

public class UnlockDoor : MonoBehaviour
{
    public GameObject yellowKey;
    public GameObject blueKey;
    public GameObject findTheOtherKeyText;
    public GameObject findTheKeysText;
    
    void Start()
    {
        if (findTheOtherKeyText != null)
            findTheOtherKeyText.SetActive(false);
        if (findTheKeysText != null)
            findTheKeysText.SetActive(false);
    }
    
    public void CheckKeys()
    {
        bool hasYellowKey = yellowKey == null;
        bool hasBlueKey = blueKey == null;
        
        Debug.Log("Yellow Key is null: " + hasYellowKey + ", Blue Key is null: " + hasBlueKey);
        
        if (hasYellowKey && hasBlueKey)
        {
            Debug.Log("Both keys collected - destroying door");
            StartCoroutine(DestroyDoorAfterDelay());
        }
        else if (hasYellowKey || hasBlueKey)
        {
            if (findTheOtherKeyText != null)
            {
                StartCoroutine(ShowTextTemporarily(findTheOtherKeyText));
            }
        }
        else
        {
            if (findTheKeysText != null)
            {
                StartCoroutine(ShowTextTemporarily(findTheKeysText));
            }
        }
    }
    
    IEnumerator DestroyDoorAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    
    IEnumerator ShowTextTemporarily(GameObject textObject)
    {
        textObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textObject.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckKeys();
        }
    }
}
