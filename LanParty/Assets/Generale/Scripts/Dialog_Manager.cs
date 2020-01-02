using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject preFab;
    public Queue<string> sentences;
    public bool inDialog = false,
        isTrigger;

    private GameObject popUp;
    private Text[] texts;
    private FirstLevel_script level;

    void Start()
    {
        sentences = new Queue<string>();
        level = FindObjectOfType<FirstLevel_script>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        level.stopped = true;

        popUp = Instantiate(preFab) as GameObject;


        texts = popUp.GetComponentsInChildren<Text>();
        texts[0].text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        inDialog = true;

        DisplayNextSentence();


    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        texts[1].text = sentence;
    }

    public void EndDialogue()
    {
        if (isTrigger)
            level.TriggerEvent();
        isTrigger = false;
        inDialog = false;
        level.stopped = false;
        Destroy(popUp);
        Debug.Log("conversation ended");
    }

    void Update()
    {
        if (inDialog)
            level.stopped = true;
    }
}
