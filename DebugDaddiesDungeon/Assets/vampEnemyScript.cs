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
    void Update()
    {
        if (doItOnce == false)
        {

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
 

        //rb.velocity = new Vector2(0, -1);
        //rb.velocity = new Vector2(0,1);
        //yield return new WaitForSeconds(2.0f);
        //rb.velocity = new Vector2(0, -1);
        yield return new WaitForSeconds(2.0f);


        //rb.velocity = new Vector2(0,1);
        //rb.AddForce(transform.up * 20 * Time.deltaTime);
    }
}
