using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSetup : MonoBehaviour
{
    // Setup the playerStats on level 1 startup
    // Can also setup highest level reached and currency here
    private void Awake()
    {
        PlayerPrefs.SetInt("Attack", 10);
        PlayerPrefs.SetInt("Defense", 1);
        PlayerPrefs.SetInt("Speed", 20);
    }
}
