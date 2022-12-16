using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// So far handles the health system of the player
/// Has a public method that can be called to give damage to the player
/// </summary>

public class PlayerScriptSasa : MonoBehaviour
{
    public PlayerScriptSasa player;

    public short health = 100; // Base HP set for player 
    public short damage = 10; // Base damage for the player

    /// <summary>
    /// Player takes damage
    /// Check if dead
    /// If so kill
    /// </summary>
    /// <param name="t_damage"></param>
    public void playerTakesDamage(short t_damage) // takes in the damage, takes it away from players health
    {
        health -= t_damage;
        if (isPlayerDead())
        {
            Destroy(player);
        }
    }

    /// <summary>
    /// Return true or false based on whether the player is dead or not
    /// </summary>
    /// <returns></returns>
    bool isPlayerDead() // checks if the player is dead
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
