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

    void FixedUpdate()
    {
        if (player.gameObject.GetComponent<PlayerFifi>().levelPoints >= 1)
        {
            triggered = true;
            TriggerUpgrades();
        }
    }

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

    public void removeButtons()
    {
        triggered = false;
        strengthButton.gameObject.SetActive(false);
        speedButton.gameObject.SetActive(false);
        healthButton.gameObject.SetActive(false);
    }
}
