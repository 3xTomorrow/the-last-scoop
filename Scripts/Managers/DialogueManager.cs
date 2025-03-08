using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField][Range(0,.1f)] public float typingSpeed;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text personName;
    [SerializeField] private TMP_Text responseBoxText1;
    [SerializeField] private TMP_Text responseBoxText2;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueSO[] dialogueSO;

    private DialogueSO currentDialogue;

    public bool isInDialogue = false;
    public int index = 0;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if(isInDialogue)
        {
            StartCoroutine(TypeSentence(currentDialogue.sentences[0]));
            string[] responses = currentDialogue.responses[0].Split("/");
            responseBoxText1.text = responses[0];
            responseBoxText2.text = responses[1];
        }
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        Cursor.lockState = CursorLockMode.None;
        dialogueBox.SetActive(true);
        personName.text = dialogue.nameOfPerson;
        currentDialogue = dialogue;
        isInDialogue = true;
        StartCoroutine(TypeSentence(dialogue.sentences[0]));
        string[] responses = dialogue.responses[0].Split("/");
        responseBoxText1.text = responses[0];
        responseBoxText2.text = responses[1];
    }

    public void NextSentence() {         
        if(index < currentDialogue.sentences.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentDialogue.sentences[index]));
            string[] responses = currentDialogue.responses[index].Split("/");
            responseBoxText1.text = responses[0];
            responseBoxText2.text = responses[1];
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MovementManager.Instance.EnableMovement();
        isInDialogue = false;
        dialogueBox.SetActive(false);
        index = 0;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public DialogueSO[] getDialoguesArray()
    {
        return dialogueSO;
    }

}
