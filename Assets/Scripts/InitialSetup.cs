using UnityEngine;

/* 
 * Setup the playerStats on level 1 startup
 * Can also setup highest level reached and currency here
 */
public class InitialSetup : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetInt("Attack", 5);
        PlayerPrefs.SetInt("Defense", 5);
        PlayerPrefs.SetInt("Speed", 5);
    }
}
