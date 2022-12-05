using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampEnemyScript : MonoBehaviour
{
    bool doItOnce = false;
    bool gravity = false;
    public Rigidbody2D rb;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doItOnce == false)
        {
            doItOnce = true;
            StartCoroutine(flyForce());
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (doItOnce == false)
            {
                transformToVamp();
                doItOnce = true;
            }
        }
    }


    public void transformToVamp()
    {
        box.size = new Vector2(10.0f, 10.0f);
        
    
    }

    IEnumerator flyForce()
    {


  
        yield return new WaitForSeconds(0.45f);
        //rb.velocity = new Vector2(0,1);
        rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        doItOnce = false;
        //rb.AddForce(transform.up * 20 * Time.deltaTime);
    }
}
