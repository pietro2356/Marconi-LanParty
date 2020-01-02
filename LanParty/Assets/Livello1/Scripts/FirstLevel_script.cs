using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_script : MonoBehaviour
{
    Player_movement pm;

    private int eventLoader = 0;

    public Rigidbody2D player;
    public GameObject gate,
        NPC_Luca,
        NPC_Dario;
    public bool stopped;
    void Start()
    {
        pm = FindObjectOfType<Player_movement>();
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stopped);

        switch (eventLoader)
        {
            case 0:
                if (player.position.x < -7)
                {
                    initialScene();
                    stopped = true;
                }
                else
                    stopped = false;
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
        }
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
}
