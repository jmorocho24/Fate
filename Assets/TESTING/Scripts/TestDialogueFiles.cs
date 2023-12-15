using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
            if (string.IsNullOrEmpty(line))
                continue;

            Debug.Log($"Segmenting line '{line}'");
            DIALOGUE_LINE dLine = DialogueParser.Parse(line);

            int i = 0;
            foreach(DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment in dLine.dialogue.segments)
            {
                Debug.Log($"Segment [{i++}] = '{segment.dialogue}' [signal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $"(segment.signalDelay)" : $"")}]");
            }
        }

        DialogueSystem.instance.Say(lines);
    }
}

