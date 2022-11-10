using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    public GameObject Player;
    public GameObject Projectile;
    public Transform firepoint;

    int speed = 4;
    bool canFire = false;
    float fireRate = 0.5f;
    float nextShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, Player.gameObject.transform.position) < 6 && Time.deltaTime > nextShot)
        {
            Debug.Log("Player is within the distance bloody");
            canFire = true;

            if(canFire == true)
            {
                nextShot = Time.deltaTime + fireRate;
                ShootAtPlayer();
                nextShot = 0;

            }
        }
    }

    void ShootAtPlayer()
    {
        GameObject ProjectClone = Instantiate(Projectile, firepoint.position, firepoint.rotation);
        Rigidbody2D rbProjectile = ProjectClone.GetComponent<Rigidbody2D>();
        rbProjectile.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
        canFire = false;
    }

    
    
}

