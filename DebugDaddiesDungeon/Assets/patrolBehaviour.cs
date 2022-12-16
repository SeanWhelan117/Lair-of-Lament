using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolBehaviour : StateMachineBehaviour
{
    private PatrolSpots patrol;
    public float speed;
    private int randomSpot;
    public float withinRange = 6;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();
        randomSpot = Random.Range(0, patrol.patrolPoints.Length);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, patrol.patrolPoints[randomSpot].position) > 0.05f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, patrol.patrolPoints[randomSpot].position, speed * Time.deltaTime);
        }
        else
        {
            randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        }

        if (Vector3.Distance(animator.transform.position, PlayerFifi.instance.transform.position) < withinRange)
        {
            /*Debug.Log("Player is within the distance bloody");
            animator.gameObject.GetComponent<RangedEnemyAttack>().ShootAtPlayer();
            animator.SetBool("isPatrolling", false);
            //animator.SetBool("attack", true);*/
            animator.SetBool("isShooting", true);
            animator.SetBool("isPatrolling", false);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
