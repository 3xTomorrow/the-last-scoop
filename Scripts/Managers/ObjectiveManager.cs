using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private string[] objectives;
    [SerializeField] private TMP_Text objectiveText;

    private int index = 0;

    public static ObjectiveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        objectiveText.text = "Current Objective: " + objectives[index];
    }

    public void NextObjective()
    {
        index++;
    }


}
