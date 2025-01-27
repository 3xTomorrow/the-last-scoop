using Unity.VisualScripting;
using UnityEngine;

public class ConeHolder : MonoBehaviour
{
    [SerializeField] private Transform conePrefab;
    [SerializeField] private bool hasCone = false;

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
}
