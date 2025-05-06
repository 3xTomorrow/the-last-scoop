using Unity.VisualScripting;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [SerializeField] private AudioSource lightBuzz;
    [SerializeField] private Material lightMaterial;

    private bool isOn = true;

    public void PowerLights()
    {
        if(isOn)
        {
            lightMaterial.SetColor("_EmissionColor", Color.black);
            lightBuzz.Pause();
            foreach(Light light in lights)
            {
                light.enabled = false;
            }
            isOn = false;
        } else if(!isOn)
        {
            lightMaterial.SetColor("_EmissionColor", Color.white);
            lightBuzz.UnPause();
            foreach(Light light in lights)
            {
                light.enabled = true;
            }
            isOn = true;
        }
    }
}
