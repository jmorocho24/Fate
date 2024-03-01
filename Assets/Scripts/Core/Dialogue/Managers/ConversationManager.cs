using COMMANDS;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DIALOGUE
{
    //Where we manage conversations.
    public class ConversationManager
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;

        public bool isRunning => process != null;

        private Coroutine process = null;

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
        public Coroutine StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));

            return process;
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
                dialogueSystem.ShowSpeakerName(line.speakerData.displayname);

            //Build dialogue 
            yield return BuildLineSegments(line.dialogueData);

            //Wait for user input 
            yield return WaitForUserInput();

            //Wait for user input 
            //yield return WaitForUserInput();
            //else
                //dialogueSystem.HideSpeakerName();

            //while (architect.isBuilding)
            //{
                //if (userPrompt)
                //{
                   // if (!architect.hurryUp)
                        //architect.hurryUp = false;
                    //else
                       // architect.ForceComplete();

                    //userPrompt = false;
                //}
                //yield return null;
                
                //It's trying to build line dialogue but right now it's building DL_D
            //}
        }
        IEnumerator Line_RunCommands(DIALOGUE_LINE line)
        {
            List<DL_COMMAND_DATA.Command> commands = line.commandData.commands;
            
            foreach(DL_COMMAND_DATA.Command command in commands)
            {
                if (command.waitForCompletion) 
                    yield return CommandManager.instance.Execute(command.name, command.arguments);
               else
                   CommandManager.instance.Execute(command.name, command.arguments);
            }
            
            yield return null;
        }
        IEnumerator BuildLineSegments(DL_DIALOGUE_DATA line)
        {
            for(int i = 0; i < line.segments.Count; i++)
            {
                DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment = line.segments[i];

                yield return WaitForDialogueSegmentSignalToBeTriggered(segment);

                yield return BuildDialogue(segment.dialogue, segment.appendText);
            }
        }
        IEnumerator WaitForDialogueSegmentSignalToBeTriggered(DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment) 
        { 
            switch(segment.startSignal)
            {
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.C:
                    yield return WaitForUserInput();
                    break;
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WC:
                    yield return new WaitForSeconds(segment.signalDelay);
                    break;
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WA:
                    yield return new WaitForSeconds(segment.signalDelay);
                    break;
                default:
                    break;
            }
        
        }
        IEnumerator BuildDialogue(string dialogue,bool append = false)
        {
            if (!append)
                architect.Build(dialogue);
            else 
                architect.Append(dialogue);

            //Wait for the dialogue to complete
            while (architect.isBuilding)
            {
                if (userPrompt)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = false;
                    else
                        architect.ForceComplete();

                    userPrompt = false;
                }
                yield return null;
        }   
        }
            IEnumerator WaitForUserInput()
            {
                while (!userPrompt)
                    yield return null;

                userPrompt = false;

            }
        }
    }
