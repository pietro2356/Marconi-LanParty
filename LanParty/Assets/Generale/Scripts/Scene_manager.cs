using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    public Rigidbody2D player;
    public bool stopped = true;
    public int nextScene;
    public Animator animator;



    protected Player_movement pm;
    protected int eventLoader = -3;
    protected Dialog_Manager DM;
    protected Gestore_File GF = new Gestore_File();
    protected bool firstTime = true;

    private void Start()
    {
        pm = FindObjectOfType<Player_movement>();
        DM = FindObjectOfType<Dialog_Manager>();

    }

    public void TriggerEvent()
    {
        eventLoader++;
    }

    //actually, it doesn't start the animation, he waits the end of it before starting the scene
    protected void StartAnimation()
    {
        StartCoroutine(BeginScene());
    }

    protected void LoadNextScene()
    {
        StartCoroutine(LoadScene(nextScene));
    }

    IEnumerator LoadScene(int scene)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }

    IEnumerator BeginScene()
    {
        yield return new WaitForSeconds(1);

        eventLoader++;

        StopAllCoroutines();
    }



}
