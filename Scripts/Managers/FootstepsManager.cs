using Unity.VisualScripting;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CamAnimationManager camAnimScript;

    private AudioSource footstepsAudio;

    private float range;
    private float walkingSpeed;

    private void Awake()
    {
        footstepsAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        range = camAnimScript.GetRange();
        walkingSpeed = camAnimScript.getWalkingSpeed();
        if (inputManager.GetMovementVector() != Vector2.zero)
        {
            print(range * (Mathf.Sin(Time.time * walkingSpeed)) + 1.7f);
            if (!footstepsAudio.isPlaying && (range*(Mathf.Sin(Time.time*walkingSpeed)) + 1.7f) < 1.73f)
            {
                footstepsAudio.Play();
            } else if((range * (Mathf.Sin(Time.time * walkingSpeed)) + 1.7f) >= 1.73f)
            {
                footstepsAudio.Stop();
            }
        }
        else
        {
            footstepsAudio.Stop();
        }
    }

    public void StopPlayingFootsteps()
    {
        footstepsAudio.Stop();
    }
}
