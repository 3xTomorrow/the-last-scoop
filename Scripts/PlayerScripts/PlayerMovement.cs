using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask groundMask;

    private Transform groundCheck;
    private float groundDistance = 0.4f;
    private bool isGrounded;

    private Vector3 move;
    private Vector3 velocity;

    private CharacterController characterController;

    private void Awake()
    {
        groundCheck = GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = inputManager.GetMovementVector().x;
        float z = inputManager.GetMovementVector().y;
        move = transform.right * x + transform.forward * z;

        characterController.Move(move * Time.deltaTime * moveSpeed);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }


}
