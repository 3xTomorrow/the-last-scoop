using System;
using Unity.Cinemachine;
using UnityEngine;

public class ManagerJumpscare : MonoBehaviour
{

    [SerializeField] private CinemachineCamera playerCam;

    [Header("Transform")]
    [SerializeField] private Transform managerT;
    [SerializeField] private Transform playerJumpscareSpot;
    [SerializeField] private Transform bossJumpscareSpot;
    [SerializeField] private Transform bossHeadT;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpscareSound;
    [SerializeField] private AudioSource jumpscareAudioSource;

    private bool dialogueComplete = false;

    private Transform playerCamT;
    private Animator managerAnimator;

    public event EventHandler OnJumpscare;

    private const string IS_SCARING = "isScaring";

    private void Awake()
    {
        managerAnimator = managerT.gameObject.GetComponentInChildren<Animator>();
        playerCamT = playerCam.transform;
    }

    private void Update()
    {
        if (DialogueManager.Instance.isInDialogue)
        {
            if(DialogueManager.Instance.index == 1)
                managerAnimator.SetBool(IS_SCARING, false);
        }
        else
        {
            playerCam.Lens.FieldOfView = 60;
            dialogueComplete = true;
        }
  
    }

    private void OnTriggerEnter(Collider other)
    {
        //!!!!Change to have the Manager and Player go into exact positions instead of looking at each other!!!!
        if(other.CompareTag("Player"))
        {
            Transform playerT = other.transform;
            MovementManager.Instance.DisableMovement();
            managerAnimator.SetBool(IS_SCARING, true);
            playerT.position = playerJumpscareSpot.position;
            playerT.rotation = playerJumpscareSpot.rotation;
            managerT.position = bossJumpscareSpot.position;

            playerCamT.LookAt(bossHeadT);
            playerCam.Lens.FieldOfView = 20;
            jumpscareAudioSource.PlayOneShot(jumpscareSound,1);
            DialogueManager.Instance.StartDialogue(DialogueManager.Instance.getDialoguesArray()[0]);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
