using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    // Queue<string> sentences;
    public Queue<DialogueSO.Info> dialogueInfo = new Queue<DialogueSO.Info>();

    public Canvas dialogueField;
    [SerializeField]
    TextMeshProUGUI myText;
    [SerializeField]
    TextMeshProUGUI myName;


    void Start()
    {
        //sentences = new Queue<string>();
        dialogueField.enabled = false;
    }
    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
           // StopAllCoroutines();
            DequeueDialogue();            
        }
    }

    public void EnqueueDialogue(DialogueSO db)
    {
        dialogueInfo.Clear();

        foreach (DialogueSO.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        dialogueField.enabled = true;
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            //StopAllCoroutines();
            EndDialogue();
            return;
        }
        DialogueSO.Info info = dialogueInfo.Dequeue();

        dialogueField.transform.position = new Vector3(info.character.transform.position.x, info.character.transform.position.y + 6.2f, info.character.transform.position.z + -.25f);
        myName.text = info.charName;
        myText.text = info.charText;
    }

    public void DisplayTalkPrompt(Vector3 position)
    {
        dialogueField.transform.position = position;

        myText.text = "F";
        myName.text = "";
        dialogueField.enabled = true;
    }

    void EndDialogue()
    {
        dialogueField.enabled = false;
    }
}
