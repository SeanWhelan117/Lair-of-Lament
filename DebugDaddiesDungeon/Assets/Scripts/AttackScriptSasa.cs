using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScriptSasa : MonoBehaviour
{
    public GameObject player;
    public GameObject npc;
    public PlayerFifi pl;
    public float playerSavedSpeed;
    bool didPlayerAttack = false;

    public Animator animator;

    
    // Update is called once per frame
    void Update()
    {
        if(didPlayerAttack == false)
        {
            playerSavedSpeed = pl.playerSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Just for debugging to see it works
        {
            didPlayerAttack = true; // Triggers to true when a player presses left mouse button, used for detecting attacks
            animator.SetBool("attack", true);
            pl.playerSpeed = 0;
            StartCoroutine(attackEnd());
        }
    }

    bool isPlayerInRange() // Checks if the player is in range to attack the enemy
    {
        if ((transform.position.x - npc.transform.position.x) < 0.5f)
            return true;      
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            if (didPlayerAttack) // Left click for attacking
            {
                if (isPlayerInRange())
                {
                    npc.GetComponent<NPCHealth>().NPCTakesDamage(npc.GetComponent<NPCHealth>().health, GetComponent<PlayerScriptSasa>().damage);
                    Debug.Log("I was colliding while attacking!");
                }
            }
        }
    }

    IEnumerator attackEnd()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("attack", false);
        pl.playerSpeed = playerSavedSpeed;

    }

}
