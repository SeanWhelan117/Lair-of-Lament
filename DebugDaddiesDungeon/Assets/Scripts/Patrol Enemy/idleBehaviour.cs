using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    public float withinRange = 6;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPatrolling", true);

        if (Vector3.Distance(animator.transform.position, PlayerFifi.instance.transform.position) < withinRange)
        {
            Debug.Log("Player is within the distance bloody");
            animator.gameObject.GetComponent<RangedEnemyAttack>().ShootAtPlayer();
            animator.SetBool("isPatrolling", false);
            //animator.SetBool("attack", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
