using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SendFileToParse();
        }

        // Update is called once per frame
        void SendFileToParse()
        {
            List<string> list = FileManager.ReadTextAsset("testFile");
        
            foreach(string line in list)
            {
                if (line == string.Empty)
                    continue;
                DIALOGUE_LINE dl= DialogueParser.Parse(line);
            }
        }
    }
}
