using UnityEngine;

public class ConeHolder : MonoBehaviour
{
    [SerializeField] private Transform conePrefab;

    public void SpawnCone()
    {
        Transform cone = Instantiate(conePrefab, transform.position, transform.rotation);
        cone.SetParent(transform);
    }
}
