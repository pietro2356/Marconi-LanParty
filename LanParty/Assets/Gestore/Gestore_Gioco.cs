using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Gestore_Gioco 
{
    public static void CambiaScena(int nScena)
    {
        SceneManager.LoadScene(nScena);
    }
}
