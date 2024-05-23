using DIALOGUE;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CHARACTERS
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance { get; private set; }
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();
        
        private CharacterConfigSO config => DialogueSystem.instance.config.characterConfigurationAsset;

        private const string CHARACTER_NAME_ID = "<charname>";
        private string characterRootPath => $"/Characters/[{CHARACTER_NAME_ID}";
        private string characterPreabPath => $"{characterRootPath}/Character = [{CHARACTER_NAME_ID}]";
        private void Awake()
        {
            instance = this;
        }
        public CharacterConfigData GetCharacterConfig(string characterName)
        {
            return config.GetConfig(characterName);
        }


        public Character GetCharacter(string characterName, bool createIfDoesNotExist = false)
        {
            if (characters.ContainsKey(characterName.ToLower()))
                return characters[characterName.ToLower()];
            else if (createIfDoesNotExist)
                return CreateCharacter(characterName);

            return null;
        }

        public Character CreateCharacter(string characterName)
        {
            if (characters.ContainsKey(characterName.ToLower()))
            {
                Debug.LogWarning($"A character called '{characterName}' already exists. Did not create the character.");
                return null;
            }

            CHARACTER_INFO info = GetCharacterInfo(characterName);

            Character character = CreateCharacterFromInfo(info);

            characters.Add(characterName.ToLower(), character);

            return character;
        }

        private CHARACTER_INFO GetCharacterInfo(string characterName)
        {
            CHARACTER_INFO result = new CHARACTER_INFO();

            result.name = characterName;

            result.config = config.GetConfig(characterName);

            result.prefab = GetPrefabForCharacter(characterName);
            
            return result;
        }
  

        private GameObject GetPrefabForCharacter(string characterName)
        {
            string prefabPath = FormatCharacterPath(characterPreabPath, characterName);
            return Resources.Load<GameObject>(prefabPath);
        }

        private string FormatCharacterPath (string path, string characterName) => path.Replace(CHARACTER_NAME_ID, characterName);

        private Character CreateCharacterFromInfo(CHARACTER_INFO info)
        {
            CharacterConfigData config = info.config;

            switch(config.charcaterType)
            {
                case Character.CharacterType.Text:
                    return new Character_Sprite(info.name, config, info.prefab);

                case Character.CharacterType.Sprite:
                case Character.CharacterType.SpriteSheet:
                    return new Character_Sprite(info.name, config, info.prefab);

                case Character.CharacterType.Live2D:
                    return new Character_Live2D(info.name, config, info.prefab);

                case Character.CharacterType.Model3D:
                    return new Character_Model3D(info.name, config, info.prefab);

                default:
                    return null;
                    /*if (config.charcaterType == Character.CharacterType.Text)
                        return new Character_Text(info.name, config);

                    if (config.charcaterType == Character.CharacterType.Sprite || config.charcaterType == Character.CharacterType.SpriteSheet )
                        return new Character_Sprite(info.name, config);

                    if (config.charcaterType == Character.CharacterType.Live2D)
                        return new Character_Live2D(info.name, config);

                    if (config.charcaterType == Character.CharacterType.Model3D)
                        return new Character_Model3D(info.name, config);

                    return null;
                    */

            }
        }
        private class CHARACTER_INFO
        {
            public string name = "";

            public CharacterConfigData config = null;
            public GameObject prefab;
        }
    }
}
