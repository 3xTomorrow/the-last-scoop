using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance = 2f;

    private void Update()
    {
        RaycastHit rayHit;
        if(Physics.Raycast(transform.position + transform.up*2, transform.forward, out rayHit, rayDistance, objectMask))
        {
            print(rayHit.collider.name);
        }

        Debug.DrawRay(transform.position + transform.up * 2, transform.forward * rayDistance, Color.red);
    }
}
