using UnityEngine;
using System.Collections;

public class Level3UnlockDoor : MonoBehaviour
{
    public GameObject orangeKey;
    public GameObject redKey;
    public GameObject purpleKey;
    
    public void CheckKeys()
    {
        bool hasOrangeKey = orangeKey == null;
        bool hasRedKey = redKey == null;
        bool hasPurpleKey = purpleKey == null;
        
        if (hasOrangeKey && hasRedKey && hasPurpleKey)
        {
            StartCoroutine(DestroyDoorAfterDelay());
        }
    }
    
    IEnumerator DestroyDoorAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckKeys();
        }
    }
}
