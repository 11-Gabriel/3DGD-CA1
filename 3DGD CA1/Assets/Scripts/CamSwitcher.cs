using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player;
    public CinemachineCamera activeCam;

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

