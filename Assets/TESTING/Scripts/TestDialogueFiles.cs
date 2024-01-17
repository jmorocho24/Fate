using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static DL_COMMAND_DATA;

public class TestDialogueFiles : MonoBehaviour
{
    [SerializeField] private TextAsset FileToRead = null;
    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset(FileToRead);

        foreach (string line in lines)
        {
            DIALOGUE_LINE dl = DialogueParser.Parse(line);
            for (int i = 0; i < dl.commandData.commands.Count; i++)
            {
                DL_COMMAND_DATA.Command command = dl.commandData.commands[i];
                Debug.Log($"Command [{i}] '{command.name}' has arguments [{string.Join(",", command.arguments)}]");
            }
        }
        //DialogueSystem.instance.Say(lines);
    }
}

