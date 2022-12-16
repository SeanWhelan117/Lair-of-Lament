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
    [SerializeField] private float cooldown = 3;
    private float cooldownTimer;
    int bulletSpeed = 6;

    public float withinRange = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Checks if the player is close enought to shoot at
    /// If this is true call shootPlayer and set the animation to attacking
    /// </summary>
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, PlayerFifi.instance.gameObject.transform.position) < withinRange)
        {
            Debug.Log("Player is within the distance bloody");
            ShootAtPlayer();
            anim.SetBool("attack", true);
        }

    }

    /// <summary>
    /// Shoot at the player. setup cooldown between shots
    /// Instantiate the projectile to hit the player
    /// Move the projectile towards the players location
    /// </summary>
    void ShootAtPlayer()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return; //Making sure we dont fire until the timer is at 0 

        cooldownTimer = cooldown;
        Debug.Log(cooldownTimer);

        GameObject ProjectClone = Instantiate(Projectile, firepoint.position, firepoint.rotation);
        Rigidbody2D rbProjectile = ProjectClone.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = (PlayerFifi.instance.transform.position - firepoint.position).normalized * bulletSpeed;
    }


    /// <summary>
    /// Debugging. Changing gizmo colours to red of the WireSphere when the player is within the range of the enemy
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, withinRange);
     
    }



}

