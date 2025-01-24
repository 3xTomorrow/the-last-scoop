using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance;

    public event EventHandler<NameOfInteractableArgs> OnInteract;
    public class NameOfInteractableArgs : EventArgs
    {
        public string nameOfInteractable;
        public bool isInteracting;
    }

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
            OnInteract?.Invoke(this, new NameOfInteractableArgs { nameOfInteractable = rayHit.transform.tag, isInteracting = true }) ;
        }
        else
        {
            OnInteract?.Invoke(this, new NameOfInteractableArgs { nameOfInteractable = null, isInteracting = false});
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }
}
