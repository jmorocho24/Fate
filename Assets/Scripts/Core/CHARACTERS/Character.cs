using DIALOGUE;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CHARACTERS
{
    public abstract class Character
    {
        public string name = "";
        public string displayName = "";
        public RectTransform root = null;
        public CharacterConfigData config;
        protected CharacterManager manager== CharacterManager instance; 
        public DialogueSystem dialogueSystem => DialogueSystem.instance;

        //Coroutines 
        protected Coroutine co_revealing, co_hiding;
        public bool isRevealing => co_Revealing != null;
        public bool isHiding => co_Revealing != null;
        public virtual bool isVisible == false; 
        public Character(string name, CharacterConfigData config, GameObject prefab)
        {
            this.name = name;
            displayName = name;
            this.config = config;
            if (prefab != null)
            {
                GameObject ob = Object.Instantiate(prefab, )
            }
        }

        public Coroutine Say(string dialogue) => Say(new List<string> { dialogue });
        public Coroutine Say(List<string> dialogue)
        {
            dialogueSystem.ShowSpeakerName(displayName);
            UpdateTextCuztomizationsOnScreen();
            return dialogueSystem.Say(dialogue);
        }

        public void SetNameFont(TMP_FontAsset font) => config.nameFont = font;
        public void SetDialogueFont(TMP_FontAsset font) => config.dialogueFont = font;
        public void SetNameColor(Color color) => config.nameColor = color;
        public void SetDialogueColor(Color color) => config.dialogueColor = color;

        public void ResetConfigurationData() => config = CharacterManager.instance.GetCharacterConfig(name);
        public void UpdateTextCuztomizationsOnScreen() => dialogueSystem.ApplySpeakerDataToDialogueContainer(config);
        
        public virtual Coroutine Show()
        {
            if (isRevealing)
                return co_revealing;

            if (hiding)
                manager StopCoroutine(co_hiding);
                
                co_revealing = manager.StartCoroutine(ShowingOrHiding(true));
        }

        public virtual Coroutine Hide()
        {
            if (isHiding)
                return co_hiding;
            
            if (Revealing)
                manager StopCoroutine(co_revealing);
                
            co_Hiding = manager.StartCoroutine(ShowingOrHiding(false);    
                
            return co_hiding; 
        }

        public virtual IEnumerator ShowingOrHiding()
        {
            Debug.Log("Show/Hide cannot be called from a base character type.");
            yield return null;
        }
        
        
        public enum CharacterType
        {
            Text, 
            Sprite,
            SpriteSheet,
            Live2D,
            Model3D
        }
    }
}
