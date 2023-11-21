using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{ 
    void Start()
    {
        int activescene = SceneManager.GetActiveScene().buildIndex;
    
        PlayerPrefs.SetInt("ActiveScene", activescene);
        Debug.Log("Saved");
    }

    public Position[] positions;

    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

}


