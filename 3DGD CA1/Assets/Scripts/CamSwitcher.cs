using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player; 
    public CinemachineCamera activeCam; // Camera controlled by this trigger


    void Start() // Set up camera priorities at game start
    {
        // Find your default camera and set higher priority
        var defaultCam = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>(); // Get main game camera
        if (defaultCam != null)
        {
            defaultCam.Priority = 10; // Make default camera highest priority
        }
    }

    private void OnTriggerEnter(Collider other) // Called when player enters trigger zone
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            activeCam.Priority = 1; // Make this camera active
        }
    }

    private void OnTriggerExit(Collider other) // Called when player leaves trigger zone
    {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            activeCam.Priority = 0; // Return to default camera
        }
    }

}

