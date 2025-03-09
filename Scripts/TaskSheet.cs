using System;
using UnityEngine;

public class TaskSheet : MonoBehaviour
{
    [SerializeField] private GameObject taskSheetGO;
    [SerializeField] private BossController bossScript;

    private bool readTasks = false;

    public void OpenTaskSheet()
    {
        MovementManager.Instance.DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        taskSheetGO.SetActive(true);
        readTasks = true;
        bossScript.SitDown();
    }

    public void CloseTaskSheet()
    {
        MovementManager.Instance.EnableMovement();
        Cursor.lockState = CursorLockMode.Locked;
        taskSheetGO.SetActive(false);
    }

    public bool GetReadTasks()
    {
        return readTasks;
    }
}
