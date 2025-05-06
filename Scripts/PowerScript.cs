using Unity.VisualScripting;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    [SerializeField] private Light[] lights;

    private bool isOn = true;

    public void PowerLights()
    {
        if(isOn)
        {
            foreach(Light light in lights)
            {
                light.enabled = false;
            }
        } else if(!isOn)
        {
            foreach(Light light in lights)
            {
                light.enabled = true;
            }
        }
    }
}
