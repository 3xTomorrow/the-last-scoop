using System;
using UnityEngine;

public class ManagerJumpscare : MonoBehaviour
{
    [SerializeField] private MovementManager movementManager;
    [SerializeField] private Transform playerT;
    [SerializeField] private Transform managerT;
    [SerializeField] private AudioClip jumpscareSound;
    [SerializeField] private AudioSource jumpscareAudioSource;

    private Animator managerAnimator;

    public event EventHandler OnJumpscare;

    private const string IS_SCARING = "isScaring";

    private void Awake()
    {
        managerAnimator = managerT.gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            movementManager.DisableMovement();
            managerAnimator.SetBool(IS_SCARING, true);
            managerT.position = new Vector3(2.7f, managerT.position.y, managerT.position.z);
            managerT.LookAt(playerT, Vector3.up);
            playerT.LookAt(managerT, Vector3.up);
            jumpscareAudioSource.PlayOneShot(jumpscareSound,1);
            OnJumpscare?.Invoke(this, EventArgs.Empty);
        }
    }
}
