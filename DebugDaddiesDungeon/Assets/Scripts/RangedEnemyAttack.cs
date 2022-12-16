using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemyAttack : MonoBehaviour
{
    public GameObject Player;
    public GameObject Projectile;
    public Transform firepoint;
    public Animator anim;
    [SerializeField] private float cooldown = 1;
    private float cooldownTimer;
    int bulletSpeed = 6;

    public float withinRange = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, PlayerFifi.instance.gameObject.transform.position) < withinRange)
        {
            Debug.Log("Player is within the distance bloody");
            ShootAtPlayer();
            anim.SetBool("attack", true);
        }

    }

    public void ShootAtPlayer()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return; //Making sure we dont fire until the timer is at 0 

        cooldownTimer = cooldown;
        Debug.Log(cooldownTimer);

        GameObject ProjectClone = Instantiate(Projectile, firepoint.position, firepoint.rotation);
        Rigidbody2D rbProjectile = ProjectClone.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = (PlayerFifi.instance.transform.position - firepoint.position).normalized * bulletSpeed;
    }

    //Debugging 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, withinRange);
     
    }



}

