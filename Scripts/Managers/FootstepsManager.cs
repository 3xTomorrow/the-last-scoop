using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private AudioSource footstepsAudio;

    private void Awake()
    {
        footstepsAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (inputManager.GetMovementVector().magnitude > 0)
        {
            if (!footstepsAudio.isPlaying)
            {
                footstepsAudio.Play();
            }
        }
        else
        {
            footstepsAudio.Stop();
        }
    }
}
