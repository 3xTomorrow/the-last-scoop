using System.Threading;
using Unity.Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField][Range(10f,500f)] private float mouseSens = 10f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform playerTransform;

    private Transform camTransform;

    private float mouseX;
    private float mouseY;

    private float xRotation;

    private void Awake()
    {
        camTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX = inputManager.GetLookVector().x * mouseSens * Time.deltaTime;
        mouseY = inputManager.GetLookVector().y * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
