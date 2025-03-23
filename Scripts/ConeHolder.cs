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
    
    public enum IceCreamFlavor {CookieDough, CoookiesNCream, MintChip, RockyRoad, Vanilla, Chocolate };

    private bool hasCone = false;
    private bool hasFirstScoop = false;
    private bool hasSecondScoop = false;
    private bool hasSoftServe = false;

    public void SpawnCone()
    {
        if (!hasCone)
        {
            coneClone = Instantiate(conePrefab, transform.position, transform.rotation);
            coneClone.SetParent(transform);
            hasCone = true;
        }
    }

    /// <summary>
    /// <br>Adds in a scoop of ice cream to the cone</br>
    /// <br>Will add a second scoop on top of first if there is a first.</br>
    /// </summary>
    /// <param name="flavor">Flavor that scooped onto the cone</param>
    public void AddScoop(IceCreamFlavor flavor)
    {
        if (hasCone)
        {
            for(int i = 0; i < scoopPrefabs.Length; i++)
            {
                if (i == (int)flavor)
                {
                    if((int) flavor < 4 && !hasSoftServe)
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
                    } else
                    {
                        if(!hasSoftServe)
                        {
                            scoopOneClone = Instantiate(scoopPrefabs[i], scoopOneLocation.position + (Vector3.down * .05f), scoopOneLocation.rotation);
                            scoopOneClone.SetParent(scoopOneLocation);
                            hasSoftServe = true;
                        }
                    }

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
        if (hasFirstScoop || hasSoftServe)
        {
            Destroy(scoopOneClone.gameObject);
            hasFirstScoop = false;
            hasSoftServe = false;
        }
        if (hasCone)
        {
            Destroy(coneClone.gameObject);
            hasCone = false;
        }
        
    }
}
