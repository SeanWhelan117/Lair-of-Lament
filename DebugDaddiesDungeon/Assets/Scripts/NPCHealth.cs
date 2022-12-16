using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Used for all NPCs, Example of Factory for handling all hp for enemies
///  Excludes Player, player is handled in player script.
///  
///
/// </summary>


public class NPCHealth : MonoBehaviour
{
    [Header("Objects and Scripts")]
    public GameObject npc;
    public GameObject XP;

    [Header("Variables")]
    public short health;
  

    public short damage;

    /// <summary>
    /// On start the NPCs health assign function is called
    /// </summary>
    private void Start()
    {
        assignHealthToNPC(); // This will assign health to the NPC, depending on the type of enemy!
    }

    /// <summary>
    /// Assign health checks for which layer the npc is on and then sets the health based on that.
    /// They are all on the same layer but differnet order in that layer so one function can set the damage and health of each NPC seperately.
    /// IE the grunt enemy will be on a specific layer, and their health and damage will be different to NPCs of different types
    /// </summary>
    public void assignHealthToNPC() // DO NOT EDIT LAYERS
    {
        if (npc.layer == 10) // 10th layer is GRUNT !!!!DO NOT EDIT!!!!
        {
            damage = 4;
            health = 10;
        }

        if (npc.layer == 11) // 11th layer is RANGED !!!!DO NOT EDIT!!!!
        {
            damage = 3;
            health = 15;
        }

        if (npc.layer == 12) // 12th layer is BRUTE !!!!DO NOT EDIT!!!!
        {
            damage = 7;
            health = 20;
        }

        if (npc.layer == 13) // 13th layer is BOSS !!!!DO NOT EDIT!!!!
        {
            damage = 0;
            health = 50;
        }
    }

    private void Update()
    {

        
    }
    
    /// <summary>
    /// Instantiate / Spawn XP orbs to give the player XP when they kill an NPC
    /// </summary>
    private void spawnXP()
    {
        Instantiate(XP, this.gameObject.transform.position, this.gameObject.transform.rotation);

    }

    /// <summary>
    /// Take an amount of damage from the NPCs health.
    /// Also call function to check if the NPC is dead
    /// If this is the case then Destroy the NPC and do the spawnXP from earlier.
    /// </summary>
    /// <param name="t_health"></param>
    /// <param name="t_damage"></param>
    public void NPCTakesDamage(short t_health, short t_damage) // takes in the damage done by the player and the NPCs health
    {
        t_health -= t_damage;
        if (isNPCDead())
        {
            Destroy(npc);
            spawnXP();
        }
    

        //npc.health = t_health;  Placeholder for getting npcs health set after taking damage
        health = t_health;
    }

    /// <summary>
    /// This is the fucntion which returns a bool for if the player is dead or not
    /// If the NPCs health is lower than or equal to 0 then return true
    /// else return low
    /// </summary>
    /// <returns></returns>
    bool isNPCDead() // checks if the NPC is dead and returns a true or false
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
