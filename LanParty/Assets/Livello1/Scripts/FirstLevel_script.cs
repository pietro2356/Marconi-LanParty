using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_script : MonoBehaviour
{
    Player_movement pm;

    private int eventLoader = -2;

    public Rigidbody2D player;
    public GameObject gate,
        NPC_Luca,
        NPC_Dario;
    public Camera_Behaviour mainCamera;
    public Transform 
        roofDoor,
        movingPlatform;
    public Lever_behaviour lever1,
        lever2;
    public GameObject nextScene;

    public bool stopped = false;


    private float startingTime;
    private bool firstTime = true;
    private Dialog_Manager DM;
    private Gestore_File GF = new Gestore_File();

    void Start()
    {
        pm = FindObjectOfType<Player_movement>();
        DM = FindObjectOfType<Dialog_Manager>();
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stopped);

        eventHandler();

        if (lever1.isMoving)
            cameraHandler(roofDoor, lever1);

        if (lever2.isMoving)
            cameraHandler(movingPlatform, lever2);
    }

    void initialScene()
    {
        player.transform.position = new Vector3(player.position.x + 0.03f, player.position.y);
    }

    public void TriggerEvent()
    {
        eventLoader++;
        Debug.Log(eventLoader);

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
                    if (NPC_Dario.transform.position.x > 30)
                        NPC_Dario.transform.position = new Vector3(NPC_Dario.transform.position.x - 0.3f, NPC_Dario.transform.position.y);
                    else
                        Destroy(NPC_Dario);
                }
                break;
            case 3:
                Gestiore_Gioco.CambiaScena(3);
                break;
        }
    }

    void cameraHandler(Transform target, Lever_behaviour lever)
    {
        Debug.Log(" time" + (Time.time - startingTime));

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
