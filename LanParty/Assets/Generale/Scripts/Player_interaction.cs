using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interaction : MonoBehaviour
{
    private Collider2D entity;
    private Dialogue dialogue;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            entity = other;
            if (other.GetComponent<SpriteRenderer>().color != Color.green)
                other.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
            other.GetComponent<SpriteRenderer>().color = Color.white;
        entity = null;


    }

    void Update()
    {
        if (entity != null)
            if (entity.name == "NPC" && Input.GetKeyDown(KeyCode.Space))
            {
                entity.GetComponent<SpriteRenderer>().color = Color.green;
                entity.GetComponent<NPC_behaviour>().TriggerDialogue();
            }
            else if (entity.name == "lever" && Input.GetKeyDown(KeyCode.Space))
                entity.GetComponent<Lever_behaviour>().isActivated = !entity.GetComponent<Lever_behaviour>().isActivated;
    }


}
