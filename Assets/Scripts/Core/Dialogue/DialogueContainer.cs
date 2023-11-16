using UnityEngine;
using TMPro;
namespace DIALOGUE
{
    //This is our dialogue container, so basically where our text variables go.
    [System.Serializable]

    public class DialogueContainer
    {
        public NameContainer nameContainer = new NameContainer();
        public GameObject root;
        //public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
    }
    
}
