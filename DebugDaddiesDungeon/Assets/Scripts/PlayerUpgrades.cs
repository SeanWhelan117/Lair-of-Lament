using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script will check for the button presses when the player levels up
/// It will trigger the buttons to true when the level up happens, and it will add listeners to each button
/// each button keeps track of how many times it has been leveled up
/// 
/// TODO: 1. Save this information into a file when the player wants to continue the game
///       2. Call the actual function that will increase the selected levelup
///       3. Add a limit for a specific level up
///       4. Check for these limits with an if statement inside the functions for incrementing the level of upgrade.
///
/// </summary>
public class PlayerUpgrades : MonoBehaviour
{
    public GameObject player;

    public Button strengthButton;
    public Button speedButton;
    public Button healthButton;

    short strength = 0;
    short speed = 0;
    short health = 0;

    // Need to add more upgrades

    void TriggerUpgrade()
    {
        strengthButton.gameObject.SetActive(true);
        speedButton.gameObject.SetActive(true);
        healthButton.gameObject.SetActive(true);

        strengthButton.onClick.AddListener(addStrengthToPlayer);
        speedButton.onClick.AddListener(addMaxSpeedToPlayer);
        healthButton.onClick.AddListener(addMaxHealthToPlayer);
    }

    void addStrengthToPlayer()
    {
        strength++;
        // Call something to make give the player increased strength
        removeButtons();
    }

    void addMaxHealthToPlayer()
    {
        health++;
        // Call something to make give the player increased health
        removeButtons();
    }

    void addMaxSpeedToPlayer()
    {
        speed++;
        // Call something to make give the player increased speed
        removeButtons();
    }

    public void removeButtons()
    {
        strengthButton.gameObject.SetActive(false);
        speedButton.gameObject.SetActive(false);
        healthButton.gameObject.SetActive(false);
    }
}
