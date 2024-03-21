using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using TMPro;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        public TMP_FontAsset tempFont;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            Character Rose = CharacterManager.instance.CreateCharacter("Rose");
            Character Elen = CharacterManager.instance.CreateCharacter("Elen");
            Character Ben = CharacterManager.instance.CreateCharacter("Benjamin");

            List<string> lines = new List<string>()
            {
                "Hi, there!",
                "My name is Elen",
                "What's your name?",
                "Oh,{wa 1} that's a very nice."
            };

            

            Elen.SetNameColor(Color.red);
            Elen.SetDialogueColor(Color.green);
            Elen.SetNameFont(tempFont);
            Elen.SetDialogueFont(tempFont);

            yield return Elen.Say(lines);

            lines = new List<string>()
            {
                "I am Rose.",
                "More lines{c}Here."
            };

            yield return Rose.Say(lines);

            yield return Ben.Say("This is a line that I want to say.{a} It is a simple line.");
            
            Debug.Log("Finished");
        }
    }
}