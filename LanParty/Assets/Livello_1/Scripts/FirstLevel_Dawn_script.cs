using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_Dawn_script : Scene_manager
{
    public Transform NPC_Gianni;


    private void Update()
    {
        eventHandler();
    }

    void eventHandler()
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

                    dialogue[0] = GC.PrendiDialogo(48);

                    DM.StartDialogue(dialogue);
                }
                break;
            case -1:
                if (NPC_Gianni.position.x > 26)
                {
                    initialScene();
                    stopped = true;
                }
                else
                {
                    stopped = false;
                    eventLoader++;
                }
                break;
            case 0:
                introduction();
                break;
            case 2:
                LoadNextScene();
                break;


        }
    }

    void initialScene()
    {
        NPC_Gianni.position = new Vector3(NPC_Gianni.position.x - 0.1f, NPC_Gianni.position.y);
    }

    void introduction()
    {
        if (DM.inDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DM.DisplayNextSentence();
        }
        else
        {
            if (firstTime)
            {
                string[] dialogue = new string[5];

                for (int i = 0; i < 5; i++)
                {
                    dialogue[i] = GC.PrendiDialogo(49+i);
                }
                

                DM.StartDialogue(dialogue);
                firstTime = false;
            }
            else
                eventLoader++;
        }
    }
}
