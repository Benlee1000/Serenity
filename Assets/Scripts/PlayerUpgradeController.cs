using UnityEngine;
using TMPro;

/*
 * Adds button functionality for the upgrade menu
 * 
 */
public class PlayerUpgradeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackUpgradeText;
    [SerializeField] private TextMeshProUGUI defenseUpgradeText;
    [SerializeField] private TextMeshProUGUI seppedUpgradeText;

    [SerializeField] private GameObject player;
    private PlayerController playerController;

    private string[] upgradeStrings = { "Attack +", "Defense +", "Speed +" };
    private int attackVal, defenseVal, speedVal;

    private void Start()
    {
        // Set attack, defense, speed upgrades from 1-5
        // Can be changed later to implement scaling
        attackVal = Random.Range(1, 6);
        defenseVal = Random.Range(1, 6);
        speedVal = Random.Range(1, 6);

        attackUpgradeText.text = upgradeStrings[0] + attackVal.ToString();
        defenseUpgradeText.text = upgradeStrings[1] + defenseVal.ToString();
        seppedUpgradeText.text = upgradeStrings[2] + speedVal.ToString();

        playerController = player.GetComponent<PlayerController>();
    }

    // When button is clicked, the correct stat is upgraded.
    // Then make scene transition.
    public void UpgradeAttack()
    {
        // Upgrade the player's Attack
        playerController.UpgradeAttack(attackVal);

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.getCurrentScene() + 1));
        
    }
    public void UpgradeDefense()
    {
        // Upgrade the player's Defense
        playerController.UpgradeDefense(defenseVal);

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.getCurrentScene() + 1));

    }
    public void UpgradeSpeed()
    {
        // Upgrade the player's Speed
        playerController.UpgradeSpeed(speedVal);

        // Use the loader to find the current scene, then increase it by 1.
        Loader.Load((Loader.Scene)(Loader.getCurrentScene() + 1));

    }
}
