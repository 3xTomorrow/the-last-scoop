using Unity.VisualScripting;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [SerializeField] private AudioSource lightBuzz;
    [SerializeField] private Material lightMaterial;
    
    private AudioSource killSwitch;

    private bool isOn = true;

    private void Awake()
    {
        killSwitch = GetComponent<AudioSource>();
    }

    public void PowerLights()
    {
        if (!killSwitch.isPlaying)
        {
            if (isOn)
            {
                lightMaterial.SetColor("_EmissionColor", Color.black);
                killSwitch.Play();
                lightBuzz.Pause();
                foreach (Light light in lights)
                {
                    light.enabled = false;
                }
                isOn = false;
            }
            else if (!isOn)
            {
                lightMaterial.SetColor("_EmissionColor", Color.white);
                killSwitch.Play();
                lightBuzz.UnPause();
                foreach (Light light in lights)
                {
                    light.enabled = true;
                }
                isOn = true;
            }
        }
    }
}
