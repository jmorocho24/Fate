using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F5))
            SaveGame();
        if (Input.GetKeyUp(KeyCode.L))
            LoadGame();
    }

    private void SaveGame()
    {
        //Type position when used in the video is lowercase p.
        SaveData saveData = new SaveData();
        saveData.positions = new SaveData.Position[1]; //Just example and do it how you should actually do it
        saveData.positions[0] = new SaveData.Position();
        saveData.positions[0].x = transform.position.x;
        saveData.positions[0].y = transform.position.y;
        saveData.positions[0].z = transform.position.z;
        SaveManager.SaveGameState(saveData);

    }

    private void LoadGame()
    {
        SaveData saveData = SaveManager.LoadGameState();
        if (saveData != null)
            transform.position = new Vector3(saveData.positions[0].y, saveData.positions[0].z);
    }




}

