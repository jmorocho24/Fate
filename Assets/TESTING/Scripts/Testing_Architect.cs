using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;
// File where we code the build type, basically specify the color, 
namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "I took in a sigh of relief, because I knew it was going to be a good day today.",
            "I rushed down the stairs to the kitchen when I saw my dad in an apron and my twin brother Ruby was sitting down on a stool next to the table island.",
            "My dad gave me a warm- hearted look and I replied with a loving smile back.",
            "Then he tenderly said “Rose come eat your pancake that I drew Woody on”.",
            "My Dad’s name was Asus and I adored because he would always make time to play with us in arcades and make us pancake art of whatever our favorite movie character was at the time.",
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            string longLine = "I sneezed";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }

            else
            {
                architect.Build(longLine);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //architect.Append(longLine);
                architect.Append(lines[Random.Range(0, lines.Length)]);

            }
        }
    }
}
         



