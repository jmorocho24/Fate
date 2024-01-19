using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance { get; private set; }
    private static Coroutine process = null;
    public static bool isRunningProcess => process != null;
    private CommandDatabase database;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            database = new CommandDatabase();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] extensionTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(CMD_DatabaseExtension))).ToArray();

            foreach(Type extension in extensionTypes){
                MethodInfo extendMethod = extension.GetMethod("Extend");
                extendMethod.Invoke(null, new object[] {database});
            }
        }
        else 
            DestroyImmediate(gameObject);
    }

    public Coroutine Execute(string commandName, params string[] args)
    {
        Delegate command = database.GetCommand(commandName);


        if (command == null)
            return null;

        if (command is Action)
            command.DynamicInvoke();
        else if (command is Action<string>)
            command.DynamicInvoke(args[0]);
        else if (command is Action<string[]>)
            command.DynamicInvoke((object)args);
        
    }

    private Coroutine StartProcess(string commandName, Delegate command, string[] args)
    {
        StopCurrentProcess();

        process = StartCoroutine(RunningProcess(command, args));
        
        return process;
    }
    private void StopCurrentProcess()
    {
        if (process != null)
            StopCoroutine(process);

        process = null;
    }

    private IEnumerator RunningProcess(Delegate process, string[] args) 
    { 
        
    
    }
}
