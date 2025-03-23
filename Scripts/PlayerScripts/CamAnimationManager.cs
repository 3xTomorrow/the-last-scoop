using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

public class CamAnimationManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private float speed = 3f;
    private float walkingSpeed;
    private float range = 0.05f;
    private float speedBeforeStop;
    private float cameraY;

    private Transform camT;

    private void Awake()
    {
        camT = GetComponent<Transform>();
    }

    private void Start()
    {
        walkingSpeed = speed *2.7f;
    }

    private void Update()
    {
        if(inputManager.GetMovementVector() != Vector2.zero)
        {
            cameraY = range * (Mathf.Sin(Time.time * (walkingSpeed))) + 1.7f;
        } else
        {
            cameraY = range * (Mathf.Sin(Time.time * speed)) + 1.7f;
        }
        
        camT.localPosition = new Vector3(0,cameraY,-.02f);

    }

    public void PauseAnimation()
    {
        speedBeforeStop = speed;
        speed = 0;
    }

    public void ResumeAnimation()
    {
        speed = speedBeforeStop;
    }

    public float GetRange()
    {
        return range;
    }
    public float getWalkingSpeed()
    {
        return walkingSpeed;
    }
}
