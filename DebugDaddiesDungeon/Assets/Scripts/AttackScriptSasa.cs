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
    public float withinRange = 1.0f;
    public bool NPCinRange = false;


    // Update is called once per frame
    void Update()
    {

        if (!didPlayerAttack)
        {
            playerSavedSpeed = pl.playerSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            didPlayerAttack = true;
            animator.SetBool("attack", true);
            pl.playerSpeed = 0;
            StartCoroutine(attackEnd());
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            didPlayerAttack=false;

        }

        if (NPCinRange)
        {
            if (NPCinRange && didPlayerAttack)
            {
                npc.gameObject.GetComponent<NPCHealth>().NPCTakesDamage(npc.gameObject.GetComponent<NPCHealth>().health, pl.GetComponent<PlayerFifi>().damage);
                Debug.Log("I was colliding while attacking!");
                didPlayerAttack = false;

            }
        }
    }


    //bool isPlayerInRange(GameObject Npc) // Checks if the player is in range to attack the enemy
    //{
    //    if ((transform.position.x - Npc.transform.position.x) < withinRange)
    //        return true;      
    //    else
    //        return false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            npc = collision.gameObject;
            NPCinRange = true;
        }
        else
            NPCinRange = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            NPCinRange = false;
        }
    }

    IEnumerator attackEnd()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("attack", false);
        pl.playerSpeed = playerSavedSpeed;

    }

}
