using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player;
    public CinemachineCamera activeCam;


    void Start()
    {
        // Find your default camera and set higher priority
        var defaultCam = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
        if (defaultCam != null)
        {
            defaultCam.Priority = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }


    }

}

