using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampEnemyScript : MonoBehaviour
{
    bool doItOnce = false;
    bool gravity = false;
    bool afterTransform = false;
    public Rigidbody2D rb;
    public BoxCollider2D box;
    public Animator sprite;
    public int randomDmg;

    public PlayerFifi player;
    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
          
            //if (rb.transform.position.x - player.transform.position.x < 2.0f)
            //{
            //    sprite.SetBool("atc", false);
            //    Debug.Log("att no");
            //    box.size = new Vector2(0.8f, 0.9f);
            //}
        }
        if (rb.transform.position.x - player.transform.position.x > 0.95f)
        {
            sprite.SetBool("atc", true);
            box.size = new Vector2(0.7f, 1.5f);
            //player.TakeDamage(randomDmg);
            Debug.Log("att");

        }
        if (rb.transform.position.x - player.transform.position.x > 1.05f)
        {
            sprite.SetBool("atc", false);
            box.size = new Vector2(0.7f, 0.9f);
            Debug.Log("att no");

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (doItOnce == false && rb.transform.position.x - player.transform.position.x < 5.0f)
            {
                transformToVamp();
                doItOnce = true;
                sprite.SetBool("transform", true);
                afterTransform = true;
            }
            move = true;
        }


    }


    public void transformToVamp()
    {
      box.size = new Vector2(0.7f, 0.9f);
        
    }

    IEnumerator flyForce()
    {
        yield return new WaitForSeconds(0.45f);
        //rb.velocity = new Vector2(0,1);
        rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        gravity = false;
     
    }




    public void moveTowardPlayer()
    {

        if (afterTransform == true)
        {
            if (rb.transform.position.x > player.transform.position.x)
            {
                rb.transform.position -= new Vector3(0.06f, 0.0f);
                rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.x < player.transform.position.x)
            {
                rb.transform.position += new Vector3(0.06f, 0.0f);
                rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        if (afterTransform == false)
        {
            if (rb.transform.position.x > player.transform.position.x)
            {
                rb.transform.position -= new Vector3(0.04f, 0.0f);
                rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.x < player.transform.position.x)
            {
                rb.transform.position += new Vector3(0.04f, 0.0f);
                rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            if (rb.transform.position.y > player.transform.position.y)
            {
                rb.transform.position -= new Vector3(0.0f, 0.04f);
            }
            if (rb.transform.position.y < player.transform.position.y)
            {
                rb.transform.position += new Vector3(0.0f, 0.04f);
            }
        }
    }
}
