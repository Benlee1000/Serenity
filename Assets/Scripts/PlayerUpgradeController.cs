using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Adds button functionality for the upgrade menu
 * 
 */
public class PlayerUpgradeController : MonoBehaviour
{
    private CombatRoomController controller;
    // When button is clicked, the correct stat is upgraded.
    // Then call transition.
    public void Upgrade()
    {
        // use static player upgrade to update the correct stat.
        
        // Then send control to the combatRoomController.
        controller.Transition();
    }

    // Display upgrade cards / screen.
    public void DisplayCards()
    {

    }

}
