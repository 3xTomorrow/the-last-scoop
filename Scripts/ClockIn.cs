using UnityEngine;

public class ClockIn : MonoBehaviour
{
    [SerializeField] private GameObject timeSheet;
    [SerializeField] private TaskSheet taskSheetScript;

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
            gameObject.layer = defaultLayer;
            beganWork = true;
        }
    }

    public bool GetBeganWork()
    {
        return beganWork;
    }
}
