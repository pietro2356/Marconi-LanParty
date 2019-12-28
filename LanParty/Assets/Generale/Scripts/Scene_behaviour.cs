using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_behaviour : MonoBehaviour
{
    Player_movement pm;
    public Rigidbody2D player;

    public bool stopped;
    void Start()
    {
        pm = FindObjectOfType<Player_movement>();
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < -7)
            initialScene();
        else
            stopped = false;
    }

    void initialScene()
    {
        player.transform.position = new Vector3(player.position.x + 0.03f, player.position.y);
    }
}
