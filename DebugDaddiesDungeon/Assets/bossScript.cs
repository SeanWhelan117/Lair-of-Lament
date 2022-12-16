using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public PlayerFifi player;

    public Rigidbody2D rb;
    public float speed = 0.06f;
    public Animator sprite;
    public bool attack = false;
    public bool move;
    public bool damage= false;
    public bool AttackOne = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerFifi>();
        move = true;
    }
    /// <summary>
    /// the boss will do certain things depedning if its moving or not, if its not moving the boss will stay idle for 1.5 seconds giving the player time to attack, after that time the boss will attack
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (move == true)
        {
            damage = false;
            speed = 0.06f;
            sprite.SetBool("walk", true);
            sprite.SetBool("attack", false);
            moveTowardPlayer();
        }


        if(attack == true)
        {
            speed = 0.0f;
            sprite.SetBool("walk", false);
            StartCoroutine(AttackPlayer());
        }

        if (damage == true && AttackOne == false)
        {
            StartCoroutine(damagePlayer());
        }

    }


    /// <summary>
    /// this function will move the boss to the player 
    /// </summary>
    public void moveTowardPlayer()
    {
        if (rb.transform.position.x > PlayerFifi.instance.transform.position.x)
        {
            rb.transform.position -= new Vector3(speed, 0.0f);
            rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (rb.transform.position.x < PlayerFifi.instance.transform.position.x)
        {
            rb.transform.position += new Vector3(speed, 0.0f);
            rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }


    }

    /// <summary>
    /// sets the animation and damage bools to true
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackPlayer()
    {

        yield return new WaitForSeconds(1.5f);
        sprite.SetBool("attack", true);
        damage = true;
        
    }


    /// <summary>
    /// allows the player to get damaged once per boss attack
    /// </summary>
    /// <returns></returns>
    IEnumerator damagePlayer()
    {
        AttackOne = true;
        player.TakeDamage(2);

        yield return new WaitForSeconds(1.5f);
        AttackOne = false;
    }

}
