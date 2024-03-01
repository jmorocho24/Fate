using CHARACTERS;
using TMPro;
using UnityEngine;

namespace DIALOGUE
{
    [CreateAssetMenu(fileName = "Dialogue Conifguration Asset", menuName = "Dialogue System/Dialogue Configuraton Asset")]
    public class DialogueSystemConfigurationSO : ScriptableObject
    {
        public const float default_fontsize_name = 34;
        public const float default_fontsize_dialogue = 30;

        public CharacterConfigSO characterConfigurationAsset;

        public Color defaultTextColor = Color.white;
        public TMP_FontAsset defaultFont;

        public float dialogueFontScale = 1f;
        public float defaultNameFontSize = default_fontsize_name;
        public float defaultDialogueFontSize = default_fontsize_dialogue;
    }
    
}


