using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTrap : MonoBehaviour
{
    public PlayerFifi player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerFifi>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Spikes hit!!!");
        }
    }
}
