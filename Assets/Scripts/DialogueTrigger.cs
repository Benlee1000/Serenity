using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Holds a reference to the dialgoue class
 * Initiates the dialogue
 */
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    // Starts dialgue after a short amount of time so assets can load
    // Can be expanded on later for more dynamic behavior based on states
    public void Start()
    {
        Invoke("TriggerDialogue", 0.1f);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
