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

    private Transform coneClone;
    private Transform scoopOneClone;
    private Transform scoopTwoClone;
    
    public enum IceCreamFlavor {CookieDough, CoookiesNCream, MintChip, RockyRoad };

    private bool hasCone = false;
    private bool hasFirstScoop = false;
    private bool hasSecondScoop = false;

    public void SpawnCone()
    {
        if (!hasCone)
        {
            coneClone = Instantiate(conePrefab, transform.position, transform.rotation);
            coneClone.SetParent(transform);
            hasCone = true;
        }
    }

    public void AddScoop(IceCreamFlavor flavor)
    {
        if (hasCone)
        {
            for(int i = 0; i < scoopPrefabs.Length; i++)
            {
                if (i == (int)flavor)
                {
                    if(!hasFirstScoop)
                    {
                        scoopOneClone = Instantiate(scoopPrefabs[i], scoopOneLocation.position, scoopOneLocation.rotation);
                        scoopOneClone.SetParent(scoopOneLocation);
                    } else if(hasFirstScoop && !hasSecondScoop)
                    {
                        scoopTwoClone = Instantiate(scoopPrefabs[i], scoopTwoLocation.position, scoopTwoLocation.rotation);
                        scoopTwoClone.SetParent(scoopTwoLocation);
                        hasSecondScoop = true;
                    }
                    hasFirstScoop = true;

                }
            }
        }
    }

    public void RemoveCone()
    {
        if(hasSecondScoop)
        {
            Destroy(scoopTwoClone.gameObject);
            hasSecondScoop = false;
        }
        if (hasFirstScoop)
        {
            Destroy(scoopOneClone.gameObject);
            hasFirstScoop = false;
        }
        if (hasCone)
        {
            Destroy(coneClone.gameObject);
            hasCone = false;
        }
        
    }
}
