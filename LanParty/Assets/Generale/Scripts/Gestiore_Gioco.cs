using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestiore_Gioco : MonoBehaviour
{
    public void CambiaScena(int index)
    {
        SceneManager.LoadScene(index);
    }
}
