using System;
using UnityEngine;

public class ManagerJumpscare : MonoBehaviour
{
    [SerializeField] private MovementManager movementManager;
    [SerializeField] private Transform playerT;
    [SerializeField] private Transform managerT;

    public event EventHandler OnJumpscare;

    private const string IS_SCARING = "isScaring";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            movementManager.DisableMovement();
            playerT.LookAt(managerT);
            OnJumpscare?.Invoke(this, EventArgs.Empty);
        }
    }
}
