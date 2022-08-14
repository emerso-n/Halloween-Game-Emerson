using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDialogueManager : MonoBehaviour
{

    [SerializeField] float typingSpeed = 0.05f;

    [SerializeField] bool playerSpeakingFirst;

    [Header("TMP Text")]
    [SerializeField] TextMeshProUGUI playerDialogueText;
    [SerializeField] TextMeshProUGUI npcDialogueText;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] string[] playerSentences;
    [TextArea]
    [SerializeField] string[] npcSentences;

    bool dialogueStarted;

    private int playerIndex;
    private int npcIndex;

    private void Start()
    {
        StartDialogue();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ContinuePlayerDialogue();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            ContinueNpcDialogue();
        }
    }
    public void StartDialogue()
    {
        if (playerSpeakingFirst)
        {
            StartCoroutine(TypePlayerDialogue());
        }
        else
        {
            StartCoroutine(TypeNpcDialogue());
        }
    }

    IEnumerator TypePlayerDialogue()
    {
        playerDialogueText.text = string.Empty;
        foreach (char letter in playerSentences[playerIndex].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    IEnumerator TypeNpcDialogue()
    {
        npcDialogueText.text = string.Empty;
        foreach (char letter in npcSentences[npcIndex].ToCharArray())
        {
            npcDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void ContinuePlayerDialogue()
    { 
        if (playerIndex < playerSentences.Length - 1)
        {
            if (dialogueStarted) playerIndex++;
            else dialogueStarted = true;
            playerIndex++;

            playerDialogueText.text = string.Empty;
            StartCoroutine(TypePlayerDialogue());
        }
    }
    public void ContinueNpcDialogue()
    {
        if (npcIndex < npcSentences.Length - 1)
        {
            if (dialogueStarted) playerIndex++;
            else dialogueStarted = true;
            npcIndex++;

            npcDialogueText.text = string.Empty;
            StartCoroutine(TypeNpcDialogue());
        }
    }

}
