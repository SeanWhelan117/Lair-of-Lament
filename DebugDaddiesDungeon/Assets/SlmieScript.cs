using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlmieScript : MonoBehaviour
{

    public float speed = 0.06f;
    public bool inZone = false;
    public Rigidbody2D rb;
    public GameObject thunder;
    public GameObject bossPrefab;
    public AudioSource sound;
    public Animator anim;
    public bool alreadyShooting = false;
    public bool transformBoss = false;
    public bool spawnOneBoss = false;
    public Transform bosspos;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public int randomNum;

    void FixedUpdate()
    {
        randomNum = Random.Range(0, 4);
        if (inZone == true)
        {
            shoot();
        }

        if (transformBoss == true && spawnOneBoss == false)
        { transformm(); }
    }

    /// <summary>
    /// able to spawn in thunder
    /// </summary>
    public void shoot()
    {
        anim.SetBool("shoot", true);
        if (alreadyShooting == false)
        {
            alreadyShooting = true;
            StartCoroutine(shotFired());
        }
    }
    /// <summary>
    /// spawning the thunger at random position 
    /// </summary>
    /// <returns></returns>
    IEnumerator shotFired()
    {

        yield return new WaitForSeconds(1.0f);
        if (randomNum == 0)
        {
            Instantiate(thunder, pos1.position, pos1.rotation);
        }
        if (randomNum == 1)
        {
            Instantiate(thunder, pos2.position, pos2.rotation);
        }
        if (randomNum == 2)
        {
            Instantiate(thunder, pos3.position, pos3.rotation);
        }
        if (randomNum == 3)
        {
            Instantiate(thunder, pos4.position, pos4.rotation);
        }
        alreadyShooting = false;

    }

    /// <summary>
    /// function to spawn in the boss when slime is transformed 
    /// </summary>
    private void transformm()
    {
        spawnOneBoss = true;
        Instantiate(bossPrefab, bosspos.position, bosspos.rotation);
        Destroy(this.gameObject);
    }

}
