using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueFiles : MonoBehaviour
{
    void Start()
    {
        //See where these lines of code belong
        //string line = "Speaker \"Dialogue \\\"goes In\\\" Here!\" Command(arguement here)";
        //DialogueParser.Parse(line);
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");

        DialogueSystem.instance.Say(lines);
    }
}
