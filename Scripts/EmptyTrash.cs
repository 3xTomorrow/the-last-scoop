using UnityEngine;

public class EmptyTrash : MonoBehaviour
{
    [SerializeField] private GameObject trash;
    [SerializeField] private ConeHolder coneHolderScript;

    private AudioSource garbageRustle;


    private void Awake()
    {
        garbageRustle = GetComponent<AudioSource>();
    }

    public void EmptyTheTrash()
    {
        gameObject.layer = 0;
        trash.SetActive(false);
        garbageRustle.Play();
    }
}
