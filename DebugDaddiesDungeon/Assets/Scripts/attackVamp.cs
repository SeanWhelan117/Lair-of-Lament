using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVamp : MonoBehaviour
{

    public vampEnemyScript enemy;
    /// <summary>
    /// Checks for enter of collision with the player so the Vampire can attack 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemy.sprite.SetBool("atc", true);
            enemy.box.size = new Vector2(0.7f, 1.5f);
            //player.TakeDamage(randomDmg);
            Debug.Log("att");
            enemy.speed = 0.0f;
        }
    }

    /// <summary>
    /// Checks for exit of collision with the player so the Vampire can stop attacking
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.sprite.SetBool("atc", false);
            enemy.box.size = new Vector2(0.7f, 0.9f);

            enemy.speed = 0.06f;
        }
    }
}
