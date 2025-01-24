using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnim;
    private const string DOOR_OPENED = "DoorOpened";
    private bool isDoorOpened;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
        isDoorOpened = false;
    }

    public void OpenDoor()
    {
        print("Is opening door");
        if(!isDoorOpened)
        {
            doorAnim.SetBool(DOOR_OPENED, true);
            isDoorOpened = true;
        }
        else if(isDoorOpened)
        {
            doorAnim.SetBool(DOOR_OPENED, false);
            isDoorOpened = false;
        }
    }

    
}
