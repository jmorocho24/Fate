using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// File where we code the build type, basically specify the color, 
namespace TESTING 
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "Hello my name is Jeicy",
            "is it a nice day",
            "Jeicy is a senior citizen",
            "Discovery channel, I turn 18 no more then 30 limit",
            "I am from massachusets",
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            string longLine = "this is a very long line that makes no sense lol hello lol, we love stuff, I love stuff , we all love stuff we love, the turkey is stuffed, today is my birthday I turn eighteen lmao, I am a libra tehee";
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
                    architect.Build(longLine);
                    //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
                //architect.Append(lines[Random.Range(0, lines.Length)]);

            } 
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                architect.Build(lines[Random.Range(0, lines.Length)]);
            }*/
    }

    }
}



