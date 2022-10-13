using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Used for all NPCs, Example of Factory for handling all hp for enemies
///  Excludes Player, player is handled in player script.
///  
///
/// </summary>


public class NPCHealth : MonoBehaviour
{
    public GameObject npc;

    public short health;

    private void Start()
    {
        //health = npc.health;  Placeholder for assigning health when the npc will be created
    }

    public void NPCTakesDamage(short t_health, short t_damage) // takes in the damage done by the player and the NPCs health
    {
        t_health -= t_damage;
        if (isNPCDead())
        {
            Destroy(npc);
        }

        //npc.health = t_health;  Placeholder for getting npcs health set after taking damage
        health = t_health;
    }

    bool isNPCDead() // checks if the NPC is dead and returns a true or false
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
