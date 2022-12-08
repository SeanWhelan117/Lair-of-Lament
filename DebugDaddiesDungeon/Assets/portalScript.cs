using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    private float upperLimit, lowerLimit;

    public bool addingScale, loweringScale;

    public GameObject Portal;

    public Vector3 initialScale;
    public Vector3 newScale;

    public Transform Target;
    public PlayerFifi player;
    public bool allowTeleport;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = Portal.transform.localScale;
        newScale = initialScale;
        addingScale = true;
        loweringScale = false;
        upperLimit = initialScale.x + 0.15f;
        lowerLimit = initialScale.x - 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(newScale.x > upperLimit)
        {
            addingScale = false;
            loweringScale = true;
        }

        if(newScale.x < lowerLimit)
        {
            addingScale = true;
            loweringScale = false;
        }

        if (allowTeleport == true)
        {
           player.rb.transform.position = Target.position;
            Debug.Log("Teleporting Player");
            allowTeleport = false;
        }
    }

    private void FixedUpdate()
    {
        if (loweringScale)
        {
            newScale.x = newScale.x - 0.005f;
            newScale.y = newScale.y - 0.005f;
        }
        if (addingScale)
        {
            newScale.x = newScale.x + 0.005f;
            newScale.y = newScale.y + 0.005f;
        }

        Portal.transform.localScale = newScale;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //make player teleport
            allowTeleport = true;
        }
    }
}
