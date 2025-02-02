using UnityEngine;

public class TaskSheet : MonoBehaviour
{
    [SerializeField] private GameObject taskSheetGO;

    private bool readTasks = false;

    public void OpenTaskSheet()
    {
        Cursor.lockState = CursorLockMode.None;
        taskSheetGO.SetActive(true);
        readTasks = true;
    }

    public void CloseTaskSheet()
    {
        Cursor.lockState = CursorLockMode.Locked;
        taskSheetGO.SetActive(false);
    }

    public bool GetReadTasks()
    {
        return readTasks;
    }
}
