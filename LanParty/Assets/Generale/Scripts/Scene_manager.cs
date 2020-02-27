﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    public Rigidbody2D player;
    public bool stopped = true;
    public int nextScene;
    



    protected Player_movement pm;
    protected int eventLoader = -3;
    protected Dialog_Manager DM;
    protected GestoreComunicazione GC;
    private Animator fader;

    private void Start()
    {
        DM = FindObjectOfType<Dialog_Manager>();
        pm = FindObjectOfType<Player_movement>();
        fader = GetComponent<Animator>();
        GC = GameObject.FindGameObjectsWithTag("GestoreGioco")[0].GetComponent<GestoreComunicazione>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U))
            eventLoader++;  
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
        fader.SetTrigger("Start");

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
