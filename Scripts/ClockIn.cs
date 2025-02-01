using UnityEngine;

public class ClockIn : MonoBehaviour
{
    [SerializeField] private GameObject timeSheet;

    private bool beganWork;

    private int defaultLayer = 0;

    public void ClockInEmployee()
    {
        if (!beganWork)
        {
            timeSheet.SetActive(true);
            print("Clocking in");
            gameObject.layer = defaultLayer;
            beganWork = true;
        }
    }

    public bool GetBeganWork()
    {
        return beganWork;
    }
}
