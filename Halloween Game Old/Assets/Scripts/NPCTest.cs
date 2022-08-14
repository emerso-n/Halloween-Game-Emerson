using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTest : MonoBehaviour
{
    //public Dialogue dialogue;
    public string myName;
    [SerializeField]
    float heightOffset = 6.3f;
    [SerializeField]
    float sideOffset;
    [SerializeField]
    float frontOffset = -0.25f;

    public DialogueSO dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           DialogueManager.Instance.DisplayTalkPrompt(new Vector3(transform.position.x + sideOffset, transform.position.y + heightOffset, transform.position.z + frontOffset));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogue)
        {
            DialogueManager.Instance.EnqueueDialogue(dialogue);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DialogueManager.Instance.DequeueDialogue();
    }

}
