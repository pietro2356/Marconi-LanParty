using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_script : Scene_manager
{


    public GameObject gate,
        NPC_Luca,
        NPC_Dario;
    public Camera_Behaviour mainCamera;
    public Transform 
        roofDoor_bookmark,
        movingPlatform_bookmark,
        lever1_bookmark,
        lever2_bookmark,
        roof_bookmark;
    public Lever_behaviour lever1,
        lever2;
    public GameObject nextScene;



    private float startingTime;
    private bool isTutorialAnimation = false;

    // Update is called once per frame
    void Update()
    {
        eventHandler();

        if (lever1.isMoving)
            cameraHandler(roofDoor_bookmark, lever1);

        if (lever2.isMoving)
            cameraHandler(movingPlatform_bookmark, lever2);
    }

    void initialScene()
    {
        player.transform.position = new Vector3(player.position.x + 0.03f, player.position.y);
    }

    void eventHandler()
    {
        switch (eventLoader)
        {
            case -2:
                introduction();
                break;

            case -1:
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
            case 1:
                if (gate.transform.position.y < 0)
                    gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y + 0.1f);
                else if (NPC_Luca != null)
                {
                    NPC_Luca.tag = "Untagged";
                    if (NPC_Luca.transform.position.x < 30)
                        NPC_Luca.transform.position = new Vector3(NPC_Luca.transform.position.x + 0.3f, NPC_Luca.transform.position.y);
                    else
                        Destroy(NPC_Luca);
                }
                break;
            case 2:
                if (NPC_Dario != null)
                {
                    NPC_Dario.tag = "Untagged";
                    if (NPC_Dario.transform.position.x > 20)
                        NPC_Dario.transform.position = new Vector3(NPC_Dario.transform.position.x - 0.3f, NPC_Dario.transform.position.y);
                    else
                    {
                        Destroy(NPC_Dario);
                        isTutorialAnimation = true;
                    }
                }
                if (NPC_Dario == null && isTutorialAnimation)
                {
                    tutorialAnimation();
                }
                break;
            case 3:
                Gestiore_Gioco.CambiaScena(3);
                break;
        }
    }

    void cameraHandler(Transform target, Lever_behaviour lever)
    {

        if (startingTime == 0)
        {
            stopped = true;
            startingTime = Time.time;

        }
        else if (Time.time - startingTime < 2)
        {
            mainCamera.target = target;
        }
        else
        {
            mainCamera.target = player.GetComponentInParent<Transform>();
            stopped = false;
            lever.isMoving = false;
            startingTime = 0;
        }
    }

    void tutorialAnimation()
    {
        if (startingTime == 0)
        {
            stopped = true;
            startingTime = Time.time;

        }
        else if (Time.time - startingTime < 2)
        {
            mainCamera.target = roof_bookmark;
        }
        else if (Time.time - startingTime > 2 && Time.time - startingTime < 4)
        {
            mainCamera.target = lever2_bookmark;
        }
        else if (Time.time - startingTime > 4 && Time.time - startingTime < 6)
        {
            mainCamera.target = lever1_bookmark;
        }
        else
        {
            stopped = false;
            isTutorialAnimation = false;
            mainCamera.target = player.GetComponentInParent<Transform>();
        }
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
                    dialogue[i] = GF.PrendiDialogo(i);
                }
                DM.StartDialogue(dialogue);
                firstTime = false;
            }
            else
                eventLoader++;
        }
    }
}
