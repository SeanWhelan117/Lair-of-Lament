using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject npc;


    // Update is called once per frame

    void Update()
    {
        
    }
    /// <summary>
    /// A function which damages the player
    /// </summary>
    void DamagePlayer()
    {
        //player.playerTakesDamage(npc.damage);
    }

    /// <summary>
    /// A function which checks for collsion with the player by using the player tag
    /// If collision happens then the damage player function is called
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }
}
