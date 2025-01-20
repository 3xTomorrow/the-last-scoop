using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
    }

    public Vector2 GetMovementVector()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookVector()
    {
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
}
