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
    [SerializeField] private Transform[] scoopPrefabs;


    
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
            for(int i = 0; i < scoopPrefabs.Length; i++)
            {
                if (i == (int)flavor)
                {
                    Transform firstScoop = Instantiate(scoopPrefabs[i], scoopOneLocation.position, scoopOneLocation.rotation);
                    firstScoop.SetParent(scoopOneLocation);
                }
            }
        }
    }
}
