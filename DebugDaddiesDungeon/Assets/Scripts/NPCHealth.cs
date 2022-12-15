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

    private void Start()
    {
        assignHealthToNPC(); // This will assign health to the NPC, depending on the type of enemy!
    }

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
            damage = 15;
            health = 50;
        }
    }

    private void Update()
    {

        
    }
    
    private void spawnXP()
    {
        Instantiate(XP, this.gameObject.transform.position, this.gameObject.transform.rotation);

    }

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

    bool isNPCDead() // checks if the NPC is dead and returns a true or false
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
