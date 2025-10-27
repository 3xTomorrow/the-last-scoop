using UnityEngine;

public class ClockIn : MonoBehaviour
{
    [SerializeField] private GameObject timeSheet;
    [SerializeField] private TaskSheet taskSheetScript;
    [SerializeField] private EmptyTrash emptyTrash;


    private bool beganWork;

    private int defaultLayer = 0;
    private int interactableLayer = 7;

    private void Update()
    {
        if(taskSheetScript.GetReadTasks() && !beganWork)
        {
            gameObject.layer = interactableLayer;
        } else
        {
            gameObject.layer = defaultLayer;
        }
    }

    public void ClockInEmployee()
    {
        if (!beganWork)
        {
            timeSheet.SetActive(true);
            emptyTrash.gameObject.layer = interactableLayer;
            ObjectiveManager.Instance.NextObjective();
            gameObject.layer = defaultLayer;
            beganWork = true;
        }
    }

    //Not sure where this is being used
    /*public bool GetBeganWork()
    {
        return beganWork;
    }*/
}
