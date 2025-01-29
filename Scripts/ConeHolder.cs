using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ConeHolder : MonoBehaviour
{
    [SerializeField] private Transform scoopOneLocation;
    [SerializeField] private Transform scoopTwoLocation;

    [Header("Prefabs")]
    [SerializeField] private Transform conePrefab;
    [SerializeField] private Transform cookieDoughPrefab;
    [SerializeField] private Transform cookiesNCreamPrefab;
    [SerializeField] private Transform mintChipPrefab;
    [SerializeField] private Transform rockyRoadPrefab;


    
    public enum IceCreamFlavor {CookieDough, CoookiesNCream, MintChip, RockyRoad };

    private bool hasCone = false;
    private bool hasFirstScoop = false;
    private bool hasSecondScoop = false;

    public void SpawnCone()
    {
        Transform cone = Instantiate(conePrefab, transform.position, transform.rotation);
        cone.SetParent(transform);
        if (hasCone)
        {
            Destroy(cone.gameObject);
        }
        hasCone = true;
    }

    public void AddScoop(IceCreamFlavor flavor)
    {
        if (hasCone)
        {
            if (flavor == IceCreamFlavor.CookieDough)
            {
                Transform cookie_dough = Instantiate(cookieDoughPrefab, scoopOneLocation.position, scoopOneLocation.rotation);
                cookie_dough.SetParent(scoopOneLocation);
            }
            else if (flavor == IceCreamFlavor.CoookiesNCream)
            {
                Transform cookies_n_cream = Instantiate(cookiesNCreamPrefab, scoopOneLocation.position, scoopOneLocation.rotation);
                cookies_n_cream.SetParent(scoopOneLocation);
            }
            else if (flavor == IceCreamFlavor.MintChip)
            {
                Transform mint_chip = Instantiate(mintChipPrefab, scoopOneLocation.position, scoopOneLocation.rotation);
                mint_chip.SetParent(scoopOneLocation);
            }
            else if (flavor == IceCreamFlavor.RockyRoad)
            {
                Transform rocky_road = Instantiate(rockyRoadPrefab, scoopOneLocation.position, scoopOneLocation.rotation);
                rocky_road.SetParent(scoopOneLocation);
            }
        }
    }
}
