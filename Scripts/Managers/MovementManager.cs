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
    ///<summary>
    ///Disables player movement while also stopping the footsteps sound and the camera animation.
    ///</summary>
    public void DisableMovement()
    {
        footstepsManagerScript.StopPlayingFootsteps();
        camAnimScript.PauseAnimation();
        camAnimScript.enabled = false;
        playerMovementScript.enabled = false;
        cameraMovementScript.enabled = false;
        footstepsManagerScript.enabled = false;
    }

    /// <summary>
    /// Enables player movement.
    /// </summary>
    public void EnableMovement()
    {
        camAnimScript.enabled = true;
        camAnimScript.ResumeAnimation();
        playerMovementScript.enabled = true;
        cameraMovementScript.enabled = true;
        footstepsManagerScript.enabled = true;
    }   
}
