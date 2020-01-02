using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interaction : MonoBehaviour
{
    private Collider2D entity;
    private Dialogue dialogue;
    private Dialog_Manager DM;

    private void Start()
    {
        DM = GetComponent<Dialog_Manager>();
    }

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
   
        if (DM != null && DM.inDialog)
            DM.EndDialogue();

        entity = null;
    }

    void Update()
    {
        if (entity != null)
            if (entity.name.StartsWith("NPC") && Input.GetKeyDown(KeyCode.Space))
            {
                entity.GetComponent<SpriteRenderer>().color = Color.green;
                entity.GetComponent<NPC_behaviour>().TriggerDialogue();
            }
            else if (entity.name.StartsWith("lever") && Input.GetKeyDown(KeyCode.Space))
                entity.GetComponent<Lever_behaviour>().isActivated = !entity.GetComponent<Lever_behaviour>().isActivated;

    }


}
