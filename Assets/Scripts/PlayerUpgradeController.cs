using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Adds button functionality for the upgrade menu
 */
public class PlayerUpgradeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackUpgradeText;
    [SerializeField] private TextMeshProUGUI defenseUpgradeText;
    [SerializeField] private TextMeshProUGUI seppedUpgradeText;
    [SerializeField] GameObject upgradeMenu;

    private string[] upgradeStrings = { "Attack +", "Defense +", "Speed +" };
    private int attackVal, defenseVal, speedVal;

    private void Start()
    {
        // Set attack, defense, speed upgrades randomly
        // Implements scaling based on level
        attackVal = Random.Range(Loader.GetCurrentScene() / 2 + 1, Loader.GetCurrentScene());
        defenseVal = Random.Range(Loader.GetCurrentScene() + 1, Loader.GetCurrentScene() + 3);
        speedVal = Random.Range(Loader.GetCurrentScene() / 2, Loader.GetCurrentScene() + 2);

        attackUpgradeText.text = upgradeStrings[0] + attackVal.ToString();
        defenseUpgradeText.text = upgradeStrings[1] + defenseVal.ToString();
        seppedUpgradeText.text = upgradeStrings[2] + speedVal.ToString();
    }

    // When button is clicked, the correct stat is upgraded.
    // Then make scene transition.
    public void UpgradeAttack()
    {
        // Upgrade the player's Attack
        PlayerPrefs.SetInt("Attack", PlayerPrefs.GetInt("Attack") + attackVal);

        // Time should move again.
        Time.timeScale = 1f;

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.GetCurrentScene() + 1));
        
    }
    public void UpgradeDefense()
    {
        // Upgrade the player's Defense
        PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + defenseVal);

        // Time should move again.
        Time.timeScale = 1f;

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.GetCurrentScene() + 1));

    }
    public void UpgradeSpeed()
    {
        // Upgrade the player's Speed
        PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + speedVal);

        // Time should move again.
        Time.timeScale = 1f;

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.GetCurrentScene() + 1));

    }
    public void DisplayUpgradeScreen()
    {
        upgradeMenu.SetActive(true);
    }
}