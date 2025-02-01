using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float rayDistance;
    [SerializeField]private ConeHolder coneHolder;


    private const string WAFER_CONES = "Wafer Cones";

    private const string COOKIE_DOUGH = "Cookie Dough";
    private const string COOKIES_N_CREAM = "Cookies 'n Cream";
    private const string MINT_CHOCOLATE_CHIP = "Mint Chocolate Chip";
    private const string ROCKY_ROAD = "Rocky Road";

    private const string TRASH = "Trash";

    private const string CLOCK_IN = "Clock In";

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
            if(rayHit.transform.tag == COOKIE_DOUGH)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.AddScoop(ConeHolder.IceCreamFlavor.CookieDough);
                }
            }
            if(rayHit.transform.tag == COOKIES_N_CREAM)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.AddScoop(ConeHolder.IceCreamFlavor.CoookiesNCream);
                }
            }
            if(rayHit.transform.tag == MINT_CHOCOLATE_CHIP)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.AddScoop(ConeHolder.IceCreamFlavor.MintChip);
                }
            }
            if(rayHit.transform.tag == ROCKY_ROAD)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.AddScoop(ConeHolder.IceCreamFlavor.RockyRoad);
                }
            }
            if (rayHit.transform.tag == TRASH)
            {   
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    coneHolder.RemoveCone();
                }
            }
            if(rayHit.transform.tag == CLOCK_IN)
            {
                if(inputManager.Player_InteractPressedThisFrame())
                {
                    rayHit.transform.GetComponent<ClockIn>().ClockInEmployee();
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
