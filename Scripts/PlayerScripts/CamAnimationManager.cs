using UnityEngine;
using UnityEngine.Animations;

public class CamAnimationManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private Animator animator;

    private const string IS_WALKING = "isWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(inputManager.GetMovementVector() != Vector2.zero)
        {
            animator.SetBool(IS_WALKING, true);
        }
        else
        {
            animator.SetBool(IS_WALKING, false);
        }
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool(IS_WALKING, isWalking);
    }

    public void PauseAnimation()
    {
        animator.speed = 0;
    }

    public void ResumeAnimation()
    {
        animator.speed = 1;
    }
}
