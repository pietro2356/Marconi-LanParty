using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_behaviour : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    public void TriggerDialogue()
    {
        Dialog_Manager DM = FindObjectOfType<Dialog_Manager>();
        if (DM.inDialog)
            DM.DisplayNextSentence();
        else
            DM.StartDialogue(dialogue);

    }
}
