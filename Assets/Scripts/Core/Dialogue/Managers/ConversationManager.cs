using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE 
{ 
    public class ConversationManager 
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;

        public bool isRunning => process != null;

        private Coroutine process= null;

        public ConversationManager conversationManager;

        private TextArchitect architect = null;

        private bool userPrompt = false;
        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem.onUserPrompt_Next += OnUserPrompt_Next;
        }

        private void OnUserPrompt_Next()
        {
            userPrompt = true;  
        }
        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation() 
        { 
            if (!isRunning)
                return;
        
            dialogueSystem.StopCoroutine(process);
            process = null;   
        }
    
        IEnumerator RunningConversation(List<string> conversation)
        { 
            for (int i = 0; i < conversation.Count; i++)
            {
                //Dont show any blank lines or try to run any logic
                if (string.IsNullOrWhiteSpace(conversation[i]))
                    continue;
                    
                DIALOGUE_LINE line = DialogueParser.Parse(conversation[i]);

                //Show dialogue
                if (line.hasDialogue)
                    yield return Line_RunDialogue(line);

                //Run any commands 
                if (line.hasCommands)
                    yield return Line_RunCommands(line);

                yield return new WaitForSeconds(1);
                
            }    
        }

        IEnumerator Line_RunDialogue(DIALOGUE_LINE line)
        {
            //Show or hide the speaker name if there one present
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker);
            else
                dialogueSystem.HideSpeakerName();

            //build dialogue
            yield return BuildDialogue(line.dialogue);
        }
        IEnumerator Line_RunCommands(DIALOGUE_LINE line) 
        {
            Debug.Log(line.commands);
            yield return null;

            //Wait for user input
            yield return WaitForUserInput();
        }

        IEnumerator BuildDialogue(string dialogue)
        {
            architect.Build(dialogue);

            while (architect.isBuilding)
            {
                if (userPrompt)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                    userPrompt = false;
                }
                yield return null;
            }
        }
        IEnumerator WaitForUserInput()
        {
            while(!userPrompt)
                yield return null;
            
            userPrompt = false;

        }
    }
}