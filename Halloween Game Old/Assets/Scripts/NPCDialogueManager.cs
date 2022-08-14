using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogueManager : MonoBehaviour
{
    #region Variables
    [System.Serializable]
    private class NpcInfo
    {
        public int characterNum;
        public string charName;
        [TextArea(4, 8)]
        public string charText;
        //public string animTrigger       
    }
    [SerializeField] NpcInfo[] _npcIfo;

    [Header ("Text Fields")]
    [SerializeField] TextMeshProUGUI nameBox;
    [SerializeField] TextMeshProUGUI textBox;

    Queue<NpcInfo> dialogueSentences = new Queue<NpcInfo>();
    [Header("Boxes and Bubbles")]
    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject nameBubble;
    RectTransform bubRect;
    [SerializeField] GameObject talkPrompt;

    [Header("NPCs")]
    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc1TextAnchor;
    [SerializeField] GameObject npc2TextAnchor;
    
    [Header("Testing")]
    [SerializeField] float bubbleHeight1;
    [SerializeField] float bubbleRL1;
    [SerializeField] float bubbleFB1;
    [SerializeField] float bubbleHeight2;
    [SerializeField] float bubbleRL2;
    [SerializeField] float bubbleFB2;
    public float boxWidth;
    public float boxHeight;
    public float textMaxWidth;
    public float nameUp;
    public float nameRL;

    Camera cam;

    #endregion

    void Start()
    {
        cam = Camera.main;
        speechBubble.SetActive(false);
        nameBubble.SetActive(false);
        talkPrompt.SetActive(false);
        bubRect = nameBubble.GetComponent <RectTransform>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DequeueDialogue();
        }
    }
    #region Prompt Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnqueueDialogue();
            talkPrompt.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (talkPrompt.activeInHierarchy == true)
        {
            talkPrompt.SetActive(false);
        }
    }
    #endregion

    #region Dialogue Queuers
    private void EnqueueDialogue()
    {
        dialogueSentences.Clear();

        foreach (NpcInfo line in _npcIfo)
        {
            dialogueSentences.Enqueue(line);
        }
        speechBubble.SetActive(true);
        nameBubble.SetActive(true);
        DequeueDialogue();
    }

    private void DequeueDialogue()
    {
        if (dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        NpcInfo info = dialogueSentences.Dequeue();
        if (info.characterNum == 1)
        {
            Vector3 camPos = cam.WorldToScreenPoint(npc1TextAnchor.transform.position);
            speechBubble.transform.position = new Vector3(camPos.x + bubbleRL1, camPos.y + bubbleHeight1, camPos.z + bubbleFB1);
        }
        else if (info.characterNum == 2)
        {
            Vector3 camPos = cam.WorldToScreenPoint(npc2TextAnchor.transform.position);
            speechBubble.transform.position = new Vector3(camPos.x + bubbleRL2, camPos.y + bubbleHeight2, camPos.z + bubbleFB2);
        }
        else
        {
            textBox.text = "ERROR: U PUT THE CHAR NUMBER IN WRONG";
        }
        nameBox.text = info.charName;
        textBox.text = info.charText;

        Vector3[] v = new Vector3[4];

        if (textBox.preferredWidth < textMaxWidth)
        {
            ((RectTransform)textBox.transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textBox.preferredWidth);
        }
        else
        {
            ((RectTransform)textBox.transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textMaxWidth);
        }
        ((RectTransform)textBox.transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textBox.preferredHeight);
        textBox.rectTransform.GetWorldCorners(v);
        bubRect.transform.position = new Vector3(v[1].x + nameRL, v[1].y + nameUp, 0f);

    }
    #endregion


    void EndDialogue()
    {
        speechBubble.SetActive(false);
        nameBubble.SetActive(false);
    }
}