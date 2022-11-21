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

    void DamagePlayer()
    {
        //player.playerTakesDamage(npc.damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }
}
