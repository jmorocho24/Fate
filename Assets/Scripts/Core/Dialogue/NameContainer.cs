using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DIALOGUE
{
    [System.Serializable]
    //The box that holds the name text on screen. Part of the dialogue container.
    public class NameContainer : MonoBehaviour
    {

        // On 2-29-24 Mrs. Boscombe pointed this root object at the NameContainer.
        // It had been pointed at the parent RootContainer, but that was causing
        // issues.
        [SerializeField] private GameObject root;

        [SerializeField] private TextMeshProUGUI nameText;


        public void Show(string nameToShow = "")
        {
            root.SetActive(true);

            if (nameToShow != string.Empty)
                nameText.text = nameToShow;
        }

        public void Hide()
        {
            //Debug.Log("I just hid the Parent Root container");
            root.SetActive(false);
        }
        public void SetNameColor(Color color) => nameText.color = color;   

        public void SetnameFont(TMP_FontAsset font) => nameText.font = font;
    }
}