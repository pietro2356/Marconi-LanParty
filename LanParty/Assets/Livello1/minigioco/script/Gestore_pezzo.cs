using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestore_pezzo : MonoBehaviour
{
    public Tubi questo;

    void OnMouseDown()
    {
        Ruota();
        GesgtioneGriglia.istanza.ControllaVincita();
    }

    public void Ruota()
    {
        transform.Rotate(0, 0, 90);
        questo.gradi = transform.rotation.z;
    }
}
