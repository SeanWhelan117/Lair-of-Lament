using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScriptSasa : MonoBehaviour
{
    public PlayerScriptSasa player;
    public NPCHealth npcHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Just for debugging to see it works
        {
            Debug.Log("I attacked");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Left click for attacking
            {
                Debug.Log("I attacked");
                //npcHealth.NPCTakesDamage(npcHealth.health, player.damage); Goal to call this
            }
        }
    }
}
