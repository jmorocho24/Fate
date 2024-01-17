using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance { get; private set; }
    private CommandDatabase database;
    private void Awake()
    {
        
        if (instance ! == null)
        {
            instance = this;

            database = new CommandDatabase();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] extensionTypes = assembly.GetTypes().Where(t => t.IsSubclassOf)
        }
        else 
            DestroyImmediate(gameObject);
    }
}
