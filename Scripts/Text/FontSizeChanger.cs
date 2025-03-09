using TMPro;
using UnityEngine;

public class FontSizeChanger : MonoBehaviour
{
    private float maxFontSize = 80f;
    private float minFontSize = 15f;
    private TMP_Text text;
    private float decreaseFactor = 1.1f;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();    
    }

    private void Update()
    {
        text.fontSize = Mathf.Pow(decreaseFactor, -text.text.Length + Mathf.Log(maxFontSize-minFontSize, decreaseFactor)) + minFontSize;
    }
}
