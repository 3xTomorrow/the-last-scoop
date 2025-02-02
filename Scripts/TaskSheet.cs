using UnityEngine;

public class TaskSheet : MonoBehaviour
{
    [SerializeField] private ClockIn clockInScript;
    [SerializeField] private MovementManager movementManager;
    [SerializeField] private GameObject taskSheetGO;

    private bool readTasks = false;

    private int defaultLayer = 0;
    private int interactableLayer = 7;

    private void Update()
    {
        if(!clockInScript.GetBeganWork())
        {
            gameObject.layer = defaultLayer;
        } else
        {
            gameObject.layer = interactableLayer;
        }
    }

    public void OpenTaskSheet()
    {
        if(clockInScript.GetBeganWork())
        {
            movementManager.DisableMovement();
            Cursor.lockState = CursorLockMode.None;
            taskSheetGO.SetActive(true);
            readTasks = true;
        }
    }

    public void CloseTaskSheet()
    {
        movementManager.EnableMovement();
        Cursor.lockState = CursorLockMode.Locked;
        taskSheetGO.SetActive(false);
    }

    public bool GetReadTasks()
    {
        return readTasks;
    }
}
