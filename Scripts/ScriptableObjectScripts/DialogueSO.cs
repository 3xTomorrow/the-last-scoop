using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    [TextArea(3,10)]public string[] sentences;
    public string[] responses;
    public string nameOfPerson;
}
