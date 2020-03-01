using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_behaviour : MonoBehaviour
{
    public float climbingSpeed = 0f;

    Player_movement player;

    void Start()
    {
        player = FindObjectOfType<Player_movement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.onLadder = true;
            Debug.Log("test");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            player.onLadder = false;
    }
}

