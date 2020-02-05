using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Gestore_Timer : MonoBehaviour
{
    Text testoTimer;

    int orarioPartenza;
    bool attivo = false;

    void Start()
    {
        testoTimer = GetComponent<Text>();
        Time.fixedDeltaTime = 1;
        orarioPartenza = 0;
    }

    public void avviaTimer()
    {
        attivo = true;
    }

    void FixedUpdate()
    {
        if (attivo && GestioneGriglia.istanza.giocoAttivo)
        {
            orarioPartenza++;
            int secondi = orarioPartenza % 60;
            int minuti = orarioPartenza / 60;
            string sec = secondi.ToString();
            string min = minuti.ToString();
            if (secondi < 10)
            {
                sec = "0" + secondi;
            }
            if (minuti<10)
            {
                min = "0" + minuti;
            }
            testoTimer.text = min + ":" + sec;
        }
    }
}
