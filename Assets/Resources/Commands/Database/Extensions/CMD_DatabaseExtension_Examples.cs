using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   // attenpt to resolve "Action" being undefined!

public class CMD_DatabaseExtension_Examples : CMD_DatabaseExtension
{
    new public static void Extend(CommandDatabase database)
    {
        // Add Action with no parameters
        database.AddCommand("print", new Action(PrintDefaultMessage));
        database.AddCommand("print_1p", new Action <string>(PrintUsermessage));
        database.AddCommand("print_mp", new Action<string[]>(PrintLines));

        //Add lambda with no parameters
        database.AddCommand("lambda", new Action(() => { Debug.Log("Printing a default message to console from lambda command."); }));
        database.AddCommand("lambda_1p", new Action<string>((arg) => { Debug.Log($"Log User Lamda Message: '{arg}'"); }));
        database.AddCommand("lambda_mp", new Action<string[]>((args) => { Debug.Log(string.Join(",", args)); } ));
        //Add courtine with no parameters
        database.AddCommand("procees", new Func<IEnumerator>(SimpleProcess));
    }

    private static void PrintDefaultMessage(){
        Debug.Log("Printing a default message to console.");
    }
    private static void PrintUsermessage(string message)
    {
        Debug.Log($"User Message: '{message}'");
    }
    private static void PrintLines(string[] lines)
    {
        int i = 1;
        foreach(string line in lines) 
        {
            Debug.Log($"{i++}. '{line}'");
        }
    }
    private static IEnumerator SimpleProcess()
    {
        for(int i = 1; i <= 5; i++)
        {
            Debug.Log($"Process Running... [{i}]");
            yield return new WaitForSeconds(1);
        }
    }
}
