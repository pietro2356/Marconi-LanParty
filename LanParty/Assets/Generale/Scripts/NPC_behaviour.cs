using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_behaviour : MonoBehaviour
{
    public bool isTrigger;
    public int firstSentence,
        sentenceNumber;

    private Gestore_File GF = new Gestore_File();
    // Start is called before the first frame update
    public void TriggerDialogue()
    {
        Dialog_Manager DM = FindObjectOfType<Dialog_Manager>();
        if (isTrigger)
        {
            DM.isTrigger = true;
            isTrigger = false;
        }
            
        if (DM.inDialog)
            DM.DisplayNextSentence();
        else
        {
            string[] dialogue = new string[sentenceNumber];

            for (int i = firstSentence, count = 0; count < sentenceNumber; i++, count++)
            {
                dialogue[count] = GF.PrendiDialogo(i);
            }


            DM.StartDialogue(dialogue);
        }
            

    }
}
