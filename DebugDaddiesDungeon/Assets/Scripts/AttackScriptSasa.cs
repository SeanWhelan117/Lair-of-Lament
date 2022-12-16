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
    /// <summary>
    /// Update function used for players attack
    /// Checks for Keycodes for the mouse.
    /// Also checks if the NPC is in range so that it can take damage
    /// </summary>
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

    /// <summary>
    /// Checks for entrance to collision with the NPC game object via tags
    /// </summary>
    /// <param name="collision"></param>
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

    /// <summary>
    /// Checks for exit to collision with the NPC game object via tags
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            NPCinRange = false;
        }
    }

    /// <summary>
    /// Coroutine for ending the attack on the NPC from the player
    /// </summary>
    /// <returns></returns>
    IEnumerator attackEnd()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("attack", false);
        pl.playerSpeed = playerSavedSpeed;

    }

}
