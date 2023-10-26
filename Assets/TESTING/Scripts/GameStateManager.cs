using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
   private static GameStateManager _instance;
   private static GameStateManager Instance
   {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
   }
    
    private GameStateManager()
    {

    }
    
}
