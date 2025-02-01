using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnim;
    private AudioSource doorOpenSound;
    private const string DOOR_OPENED = "DoorOpened";
    private bool isDoorOpened;

    private void Awake()
    {
        doorOpenSound = GetComponentInChildren<AudioSource>();
        doorAnim = GetComponent<Animator>();
        isDoorOpened = false;
    }

    public void OpenDoor()
    {
        print("Is opening door");
        if(!isDoorOpened)
        {
            if(doorOpenSound.isPlaying)
            {
                doorOpenSound.Stop();
            }
            doorAnim.SetBool(DOOR_OPENED, true);
            doorOpenSound.Play();
            isDoorOpened = true;
        }
        else if(isDoorOpened)
        {
            doorAnim.SetBool(DOOR_OPENED, false);
            isDoorOpened = false;
        }
    }

    
}
