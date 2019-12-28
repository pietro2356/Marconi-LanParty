using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject preFab;
    public Queue<string> sentences;
    public bool inDialog = false;

    private GameObject popUp;
    private Text[] texts;
    private Scene_behaviour sb;
    void Start()
    {
        sentences = new Queue<string>();
        sb = FindObjectOfType<Scene_behaviour>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sb.stopped = true;

        popUp = Instantiate(preFab) as GameObject;


        texts = popUp.GetComponentsInChildren<Text>();
        texts[0].text =  dialogue.name;

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

    void EndDialogue()
    {
        inDialog = false;
        Destroy(popUp);
        Debug.Log("conversation ended");
    }

    void Update()
    {
        sb.stopped = inDialog;
    }
}
