using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderDespawn : MonoBehaviour
{
    public PlayerFifi player;

    /// <summary>
    /// slime spawning in thunder strikes to hit player
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(thunderDespawnFunc());
        player = FindObjectOfType<PlayerFifi>();
    }

    IEnumerator thunderDespawnFunc()
    { 
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(1);
        }
    }

}
