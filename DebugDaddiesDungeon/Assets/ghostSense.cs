using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSense : MonoBehaviour
{
    public PlayerFifi player;
    public float speed = 0.06f;
    public bool move = false;
    public Rigidbody2D rb;

    public GameObject jumpScareObject;
    public AudioSource sound;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (move == true)
        {
            moveTowardPlayer();
        }
    }


    public void moveTowardPlayer()
    {
        if (rb.transform.position.x > PlayerFifi.instance.transform.position.x)
        {
            rb.transform.position -= new Vector3(speed, 0.0f);
            rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (rb.transform.position.x < PlayerFifi.instance.transform.position.x)
        {
            rb.transform.position += new Vector3(speed, 0.0f);
            rb.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
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

    public void jumpScare()
    {

        StartCoroutine(boo());
        
    }

    IEnumerator boo()
    {
        jumpScareObject.SetActive(true);
        sound.Play();
        yield return new WaitForSeconds(1.0f);
        jumpScareObject.SetActive(false);
        sound.Pause();
        Destroy(this.gameObject);
    }
}
