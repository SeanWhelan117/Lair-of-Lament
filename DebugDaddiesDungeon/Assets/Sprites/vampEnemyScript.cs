using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampEnemyScript : MonoBehaviour
{
    public bool doItOnce = false;
    public bool gravity = false;
    public bool afterTransform = false;
    public Rigidbody2D rb;
    public BoxCollider2D box;
    public Animator sprite;
    public int randomDmg;
    public float speed = 0.06f;


    public PlayerFifi player;
    public bool move = false;


    public GameObject particle;

    // Start is called before the first frame update
    /// <summary>
    /// get rigidBody
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /// <summary>
    /// get a random amount of damage between 1 and 4
    /// start the coroutine flyForce if it hasnt tranformed
    /// if gravity is false then set it to true
    /// Move towards the player 
    /// </summary>
    void FixedUpdate()
    {

        randomDmg = Random.Range(1, 4);
        if (afterTransform == false)
        {
            if (gravity == false)
            {
                gravity = true;
                StartCoroutine(flyForce());
            }
        }

    
        
        if (move == true)
        {
            moveTowardPlayer();
        }
        if (afterTransform == true)
        {
            rb.gravityScale = 1.0f;
            rb.drag = 1.0f;
        }

    }

    /// <summary>
    /// if the vamp collides with the player. Move= true
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move = true;
        }


    }

    /// <summary>
    /// Transforms the bat into the vampire
    /// Instantiate the particle of magic smoke to hide this change
    /// Then destroy said particles to reveal the transformation
    /// </summary>
    public void transformToVamp()
    {
      box.size = new Vector2(0.7f, 0.9f);
      Instantiate(particle, transform.position, transform.rotation);
      Destroy(particle, 3.0f);
    }

    /// <summary>
    /// Add force when flying using a coroutine
    /// </summary>
    /// <returns></returns>
    IEnumerator flyForce()
    {
        yield return new WaitForSeconds(0.45f);
        //rb.velocity = new Vector2(0,1);
        rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        gravity = false;
     
    }



    /// <summary>
    /// Gets a vector between the vampire and the player.
    /// Use this vector to move towards the player
    /// </summary>
    public void moveTowardPlayer()
    {

        if (afterTransform == true)
        {
            if (rb.transform.position.x > PlayerFifi.instance.transform.position.x)
            {
                rb.transform.position -= new Vector3(speed, 0.0f);
                rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.x < PlayerFifi.instance.transform.position.x)
            {
                rb.transform.position += new Vector3(speed, 0.0f);
                rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        if (afterTransform == false)
        {
            if (rb.transform.position.x > PlayerFifi.instance.transform.position.x)
            {
                rb.transform.position -= new Vector3(0.04f, 0.0f);
                rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.x < PlayerFifi.instance.transform.position.x)
            {
                rb.transform.position += new Vector3(0.04f, 0.0f);
                rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.y > PlayerFifi.instance.transform.position.y)
            {
                rb.transform.position -= new Vector3(0.0f, 0.04f);
            }
            if (rb.transform.position.y < PlayerFifi.instance.transform.position.y)
            {
                rb.transform.position += new Vector3(0.0f, 0.04f);
            }
        }
    }
}
