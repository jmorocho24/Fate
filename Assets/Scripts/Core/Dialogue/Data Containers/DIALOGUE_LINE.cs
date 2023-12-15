using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    //This file is to identify the parts of a dialogue line.
    public class DIALOGUE_LINE
    {
        public string speaker;
        public DL_DIALOGUE_DATA dialogue;
        public string commands;

        public bool hasSpeaker => speaker != string.Empty;
        public bool hasDialogue => dialogue.hasDialogue;
        public bool hasCommands => commands != string.Empty;
        public DIALOGUE_LINE(string speaker, string dialogue, string commands)
        {
            this.speaker = speaker;
            this.dialogue =  new DL_DIALOGUE_DATA(dialogue);
            this.commands = commands;
        }
    }
}