using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance;
    [SerializeField]private ConeHolder coneHolder;


    private const string WAFER_CONES = "Wafer Cones";

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
            OnInteract?.Invoke(this, new NameOfInteractableArgs { nameOfInteractable = rayHit.transform.tag, isInteracting = true }) ;
            if(rayHit.transform.GetComponent<Door>() != null)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    rayHit.transform.GetComponent<Door>().OpenDoor();
                }
            }
            if(rayHit.transform.tag == WAFER_CONES)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.SpawnCone();
                }
            }
        }
        else
        {
            OnInteract?.Invoke(this, new NameOfInteractableArgs { nameOfInteractable = null, isInteracting = false});
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }
}
