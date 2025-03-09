using System;
using UnityEngine;

public class TaskSheet : MonoBehaviour
{
    [SerializeField] private GameObject taskSheetGO;
    [SerializeField] private BossController bossScript;

    private AudioSource sheetAudio;

    private bool readTasks = false;

    private void Awake()
    {
        sheetAudio = GetComponent<AudioSource>();
    }

    public void OpenTaskSheet()
    {
        if(!readTasks)
        {
            ObjectiveManager.Instance.NextObjective();
        }

        MovementManager.Instance.DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        taskSheetGO.SetActive(true);
        readTasks = true;
        bossScript.SitDown();
        sheetAudio.Play();
    }

    public void CloseTaskSheet()
    {
        MovementManager.Instance.EnableMovement();
        Cursor.lockState = CursorLockMode.Locked;
        taskSheetGO.SetActive(false);
        sheetAudio.Stop();
    }

    public bool GetReadTasks()
    {
        return readTasks;
    }
}
