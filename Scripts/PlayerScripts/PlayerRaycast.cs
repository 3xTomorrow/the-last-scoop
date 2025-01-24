using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance;

    private void Update()
    {
        RaycastHit rayHit;
        if(Physics.Raycast(transform.position, transform.forward, out rayHit, rayDistance, objectMask))
        {
            if(rayHit.transform.GetComponent<Door>() != null)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    rayHit.transform.GetComponent<Door>().OpenDoor();
                }
            }
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }
}
