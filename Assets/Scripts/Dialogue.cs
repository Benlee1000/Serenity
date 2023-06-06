using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Stores the dialogue to display
 */
[System.Serializable]
public class Dialogue 
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
