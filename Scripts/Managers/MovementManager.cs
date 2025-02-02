using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private CameraMovement cameraMovementScript;
    [SerializeField] private FootstepsManager footstepsManagerScript;

    public void DisableMovement()
    {
        playerMovementScript.enabled = false;
        cameraMovementScript.enabled = false;
        footstepsManagerScript.enabled = false;
    }

    public void EnableMovement()
    {
        playerMovementScript.enabled = true;
        cameraMovementScript.enabled = true;
        footstepsManagerScript.enabled = true;
    }   
}
