using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance = 1.25f;

    private void Update()
    {
        RaycastHit rayHit;
        if(Physics.Raycast(transform.position + transform.up*1.9f, transform.forward, out rayHit, rayDistance, objectMask))
        {
            if(rayHit.transform.GetComponent<Door>() != null)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    rayHit.transform.GetComponent<Door>().OpenDoor();
                }
            }
        }

        Debug.DrawRay(transform.position + transform.up * 1.9f, transform.forward * rayDistance, Color.red);
    }
}
