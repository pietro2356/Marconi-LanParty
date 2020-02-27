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
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        DM.DisplayNextSentence();
                    }
                }
                else
                {
                    DM.isTrigger = true;

                    string[] dialogue = new string[2];

                    for (int i = 0; i < 2; i++)
                    {
                        dialogue[i] = GC.PrendiDialogo(i);
                    }

                    DM.StartDialogue(dialogue);
                }
                break;
            case 0:
                LoadNextScene();
                break;
        }
    }
}
