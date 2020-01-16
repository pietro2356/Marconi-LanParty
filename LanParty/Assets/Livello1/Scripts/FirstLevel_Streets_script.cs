using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_Streets_script : Scene_manager
{
    private void Update()
    {
        eventHandler();
    }

    void eventHandler()
    {
        switch (eventLoader)
        {
            case -2:
                if (player.position.x < -7)
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
            case -1:
                introduction();
                break;

            
        }
    }

    void initialScene()
    {
        player.transform.position = new Vector3(player.position.x + 0.03f, player.position.y);
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
                string[] dialogue = new string[1];
                
                    dialogue[0] = GF.PrendiDialogo(38);
                
                DM.StartDialogue(dialogue);
                firstTime = false;
            }
            else
                eventLoader++;
        }
    }
}
