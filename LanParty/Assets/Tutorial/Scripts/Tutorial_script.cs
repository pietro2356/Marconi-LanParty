using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_script : Scene_manager
{
    void Update()
    {
        eventHandler();
        Debug.Log("qui ci siamo");
    }

    void  eventHandler()
    {
        switch (eventLoader)
        {
            case -3:
                StartAnimation();
                break;
            case -2:
                if (DM.inDialog)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        DM.DisplayNextSentence();
                        eventLoader++;
                    }
                }
                else
                {
                    string[] dialogue = new string[1];

                    dialogue[0] = "test;test";

                    DM.StartDialogue(dialogue);
                }
                break;
            case 0:
                LoadNextScene();
                break;
        }
    }
}
