using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCallAttack : MonoBehaviour
{
    public bossScript bossScript;


    /// <summary>
    /// allows the boss to attack and turns off movement 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossScript.attack = true;
            bossScript.move = false;
        }

      
    }
    /// <summary>
    /// turns on the movement and turns off the attack
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossScript.move = true;
            bossScript.attack = false;

            //bossScript.attack = false;
        }


    }
}
