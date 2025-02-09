using UnityEngine;

public class ManagerJumpscare : MonoBehaviour
{
    [SerializeField] private MovementManager movementManager;
    [SerializeField] private Animator managerAnimator;
    [SerializeField] private Transform playerT;
    [SerializeField] private Transform managerT;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            movementManager.DisableMovement();
            playerT.LookAt(managerT);
        }
    }
}
