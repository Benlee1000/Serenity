using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Manages the dialogue boxes in the dialogue scene
 */
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;  
    
    private Queue<string> sentences;
    private float typingSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Displays the next sentence in the sentence queue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Types a sentence out in the dialogue box
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    // Ends the dialgue, performing next actions
    // Can be expanded on later for more dynamic behavior based on states
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        Loader.Load(Loader.Scene.Level1);
    }

}
