using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script will check for the button presses when the player levels up
/// It will trigger the buttons to true when the level up happens, and it will add listeners to each button
/// each button keeps track of how many times it has been leveled up
/// 
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

    bool triggered = false;

    // Need to add more upgrades
    /// <summary>
    /// Check if the levelPoints of the player is greater than 1
    /// If this is the case then trigger the upgrades section
    /// </summary>
    void FixedUpdate()
    {
        if (player.gameObject.GetComponent<PlayerFifi>().levelPoints >= 1)
        {
            triggered = true;
            TriggerUpgrades();
        }
    }

    /// <summary>
    /// Set the buttons for increasing stats to active
    /// Check for if the player clicks the buttons. If that happens add to the max of that specific stat
    /// </summary>
    void TriggerUpgrades()
    {
        if (triggered)
        {
            strengthButton.gameObject.SetActive(true);
            speedButton.gameObject.SetActive(true);
            healthButton.gameObject.SetActive(true);

            strengthButton.onClick.AddListener(addStrengthToPlayer);
            speedButton.onClick.AddListener(addMaxSpeedToPlayer);
            healthButton.onClick.AddListener(addMaxHealthToPlayer);
        }
    }

    /// <summary>
    /// Add to the players strength
    /// remove the levelPoints. 
    /// remove the up stat buttons 
    /// </summary>
    void addStrengthToPlayer()
    {
        if (triggered)
        {
            triggered = false;
            Debug.Log("STRONK");
            strength++;
            player.gameObject.GetComponent<PlayerFifi>().levelPoints -= 1;
            player.gameObject.GetComponent<PlayerFifi>().damage += 2;
            // Call something to make give the player increased strength
            Debug.Log(player.gameObject.GetComponent<PlayerFifi>().damage);
            removeButtons();
        }
        
    }

    /// <summary>
    /// Add to the players health
    /// remove the levelPoints. 
    /// remove the up stat buttons 
    /// </summary>
    void addMaxHealthToPlayer()
    {
        if (triggered)
        {
            triggered = false;
            Debug.Log("FATBOI");
            health++;
            player.gameObject.GetComponent<PlayerFifi>().levelPoints -= 1;
            player.gameObject.GetComponent<PlayerFifi>().increasePlayerMaxHealth();
            // Call something to make give the player increased health
            Debug.Log(player.gameObject.GetComponent<PlayerFifi>().maxHealth);
            removeButtons();
        }
    }

    /// <summary>
    /// Add to the players speed
    /// remove the levelPoints. 
    /// remove the up stat buttons 
    /// </summary>
    void addMaxSpeedToPlayer()
    {
        if (triggered)
        {
            triggered = false;
            Debug.Log("SHPEEED");
            speed++;
            player.gameObject.GetComponent<PlayerFifi>().levelPoints -= 1;
            player.gameObject.GetComponent<PlayerFifi>().PLAYER_SPEED_DEFAULT += 1.0f;
            // Call something to make give the player increased speed
            Debug.Log(player.gameObject.GetComponent<PlayerFifi>().PLAYER_SPEED_DEFAULT);
            removeButtons();
        }
    }

    /// <summary>
    /// Removes the add to stat buttons from the screen until next level up
    /// </summary>
    public void removeButtons()
    {
        triggered = false;
        strengthButton.gameObject.SetActive(false);
        speedButton.gameObject.SetActive(false);
        healthButton.gameObject.SetActive(false);
    }
}
