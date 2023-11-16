using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler  : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SaveData()
    {
        PlayerPrefs.SetString("Input", inputField.text);
        //PlayerPrefs.SetString("PlayerHealth", inputField.text);
        //PlayerPrefs.SetString("HighScore", inputField.text);
        //PlayerPrefs.SetString("hjjfhjfjfjjf", inputField.text);
        PlayerPrefs.SetFloat("PlayerMaxHealth", 100f);
    }
    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("Input");
    }

    public void OnDestroy()
    {
        PlayerPrefs.DeleteKey("Input");
        PlayerPrefs.DeleteAll();
    }
}
