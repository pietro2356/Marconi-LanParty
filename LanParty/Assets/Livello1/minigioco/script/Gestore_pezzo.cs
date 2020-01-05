using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestore_pezzo : MonoBehaviour
{
    public Tubi questo;

    void OnMouseDown()
    {
        if (GesgtioneGriglia.istanza.giocoAttivo)
        {
            Ruota();
            GesgtioneGriglia.istanza.ControllaVincita();
        }
    }

    public void Ruota()
    {
        transform.Rotate(0, 0, -90);
        questo.gradi = (int)transform.rotation.eulerAngles.z;
    }
}
