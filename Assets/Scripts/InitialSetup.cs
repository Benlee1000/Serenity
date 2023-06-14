using UnityEngine;

/* 
 * Setup the playerStats on level 1 startup
 * Can also setup highest level reached and currency here
 */
public class InitialSetup : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetInt("Attack", 1);
        PlayerPrefs.SetInt("Defense", 1);
        PlayerPrefs.SetInt("Speed", 8);
    }
}
