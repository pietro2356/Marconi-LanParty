using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_script : Scene_manager
{
    public Camera_Behaviour camera;

    private bool intro = true;
    void Update()
    {
        Debug.Log(eventLoader);
        eventHandler();
    }

    void eventHandler()
    {
        switch (eventLoader)
        {
            case -3:
                camera.isFixed = true;
                StartAnimation();
                camera.transform.position = new Vector3(player.position.x - 30, player.position.y, camera.offset.z);
                break;
            case -2:
                if (10 - Time.time > 0)
                    camera.transform.position = new Vector3(player.position.x - (10 - Time.time) * 3, player.position.y, camera.offset.z);
                else
                {
                    eventLoader++;
                    camera.isFixed = false;
                }
                break;
            case -1:
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
            case 1:
                LoadNextScene();
                break;
        }
    }
}
