using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CommandManager.instance.Execute("print");
        CommandManager.instance.Execute("print_1p", "Hello World!");
        CommandManager.instance.Execute("print_mp", "Line1", "Line2","Line3");
       
        CommandManager.instance.Execute("lambda");
        CommandManager.instance.Execute("lambda_1p", "Hello Lambda!");
        CommandManager.instance.Execute("lambda_mp", "Lambda1", "Lambda2", "Lambda3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
