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
                //internal dialogue not trying to do conversations atm 
                "I woke up to the sound of chirping blue jays and I savored the smell of darkened flour and melted butter.",
                "I took in a sigh of relief, because I knew it was going to be a good day today.",
                " I rushed down the stairs to the kitchen when I saw my dad in an apron and my twin brother Ruby was sitting down on a stool next to the table island.",
                " My dad gave me a warm- hearted look and I replied with a loving smile back.",
                " Oh,{wa 1} that's a very nice."
            };

            

            Rose.SetNameColor(Color.red);
            Rose.SetDialogueColor(Color.green);
            Rose.SetNameFont(tempFont);
            Elen.SetDialogueFont(tempFont);

            yield return Rose.Say(lines);

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