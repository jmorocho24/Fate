using UnityEngine;
using TMPro;
namespace DIALOGUE
{
    //This is our dialogue container, so basically where our text variables go.
    [System.Serializable]

    public class DialogueContainer
    {
        public NameContainer nameContainer;
        public GameObject root;
        public TextMeshProUGUI dialogueText;

        public void SetDialogueColor(Color color) => dialogueText.color = color;

        public void SetDialogueFont(TMP_FontAsset font) => dialogueText.font = font;
    }
    
}
