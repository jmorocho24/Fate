using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   // attenpt to resolve "Action" being undefined!

public class CMD_DatabaseExtension_Examples : CMD_DatabaseExtension
{
    new public static void Extend(CommandDatabase database)
    {
        // Add command with no parameters
        database.AddCommand("print", new Action(PrintDefaultMessage));
    }

    private static void PrintDefaultMessage(){
        Debug.Log("Printing a default message to console.");
    }
}
