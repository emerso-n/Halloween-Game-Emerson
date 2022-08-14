using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        //public CharacterProfile character;
        public string charName;
        [TextArea(4, 8)]
        public string charText;

        public GameObject character;

        //public EmotionType characterEmotion;

       // public bool continueCheck;

      /*  public void ChangeEmotion()
        {
            character.Emotion = characterEmotion;
        }*/

    }

    public Info[] dialogueInfo;
}
