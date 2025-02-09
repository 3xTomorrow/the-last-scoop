using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private CameraMovement cameraMovementScript;
    [SerializeField] private FootstepsManager footstepsManagerScript;
    [SerializeField] private CamAnimationManager camAnimScript;

    public void DisableMovement()
    {
        footstepsManagerScript.StopPlayingFootsteps();
        camAnimScript.SetWalking(false);
        camAnimScript.enabled = false;
        playerMovementScript.enabled = false;
        cameraMovementScript.enabled = false;
        footstepsManagerScript.enabled = false;
    }

    public void EnableMovement()
    {
        camAnimScript.enabled = true;
        playerMovementScript.enabled = true;
        cameraMovementScript.enabled = true;
        footstepsManagerScript.enabled = true;
    }   
}
