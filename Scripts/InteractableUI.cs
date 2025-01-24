using TMPro;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private PlayerRaycast playerRaycast;

    private TMP_Text interactableText;

    private string nameOfInteractable;
    private bool isInteracting;

    private void Awake()
    {
        interactableText = GetComponent<TMP_Text>();
        playerRaycast.OnInteract += OnInteractInvoked;
    }

    private void OnInteractInvoked(object sender, PlayerRaycast.NameOfInteractableArgs e)
    {
        nameOfInteractable = e.nameOfInteractable;
        isInteracting = e.isInteracting;
    }

    private void Update()
    {
        if (isInteracting)
        {
            interactableText.enabled = true;
            interactableText.text = "E - " + nameOfInteractable;
        }
        else
        {
            interactableText.enabled = false;
        }
    }
}
