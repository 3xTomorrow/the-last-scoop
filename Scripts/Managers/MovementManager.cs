using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager Instance { get; private set; }

    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private CameraMovement cameraMovementScript;
    [SerializeField] private FootstepsManager footstepsManagerScript;
    [SerializeField] private CamAnimationManager camAnimScript;

    private void Awake()
    {
        if(Instance != null && Instance != this) {
            Destroy(Instance);
        } else
        {
            Instance = this;
        }
    }

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
