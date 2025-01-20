using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private const string IS_WALKING = "isWalking";

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(inputManager.GetMovementVector() != Vector2.zero)
        {
            playerAnimator.SetBool(IS_WALKING, true);
        } else
        {
            playerAnimator.SetBool(IS_WALKING, false);
        }
    }
}
