using TMPro;
using UnityEngine;

public class FontSizeChanger : MonoBehaviour
{
    private float maxFontSize = 100f;
    private float minFontSize = 15f;
    private TMP_Text text;
    private float decreaseFactor = 1.08f;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();    
    }

    private void Update()
    {
        text.fontSize = Mathf.Pow(decreaseFactor, -text.text.Length + Mathf.Log(maxFontSize-minFontSize, decreaseFactor)) + minFontSize;
        print(Mathf.Pow(decreaseFactor, -text.text.Length + Mathf.Log(maxFontSize - minFontSize, decreaseFactor)) + minFontSize); 
    }
}
