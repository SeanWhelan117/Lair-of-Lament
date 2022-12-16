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
    /// <summary>
    /// initialise a upper and lower limit to the scale of the portal
    /// Set adding scale to true
    /// Add in an initial scale and a new scale
    /// </summary>
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
    /// <summary>
    /// Check if the newScale is outside the bounds of the upper/ lower limit
    /// If this is the case then turnt the scale around.
    /// adding to scale instead of lowering and vice versa
    /// </summary>
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

    /// <summary>
    /// Add to and lower scale
    /// Set the portals scale to said scale
    /// </summary>
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

    /// <summary>
    /// Check for collision with player, if this is true allow teleportation becomes true
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //make player teleport
            allowTeleport = true;
        }
    }
}
