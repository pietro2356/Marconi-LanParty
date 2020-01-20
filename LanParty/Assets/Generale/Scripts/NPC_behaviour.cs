using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_behaviour : MonoBehaviour
{
    public bool isTrigger;
    public int firstSentence,
        sentenceNumber;

    private GestoreComunicazione GC;
    private bool hasSpoken = false;
    // Start is called before the first frame update

    private void Start()
    {
        GC = GameObject.FindGameObjectsWithTag("GestoreGioco")[0].GetComponent<GestoreComunicazione>();
    }

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
        else if(!hasSpoken)
        {
            string[] dialogue = new string[sentenceNumber];

            for (int i = firstSentence, count = 0; count < sentenceNumber; i++, count++)
            {
                dialogue[count] = GC.PrendiDialogo(i);
            }

            hasSpoken = true;

            DM.StartDialogue(dialogue);
        }
            

    }
}
