using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingBehaviour : StateMachineBehaviour
{
    public float withinRange = 6;

    //// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, PlayerFifi.instance.transform.position) < withinRange)
        {
            animator.SetBool("attack", false);
            Debug.Log("Player is within the distance bloody");
            animator.gameObject.GetComponent<RangedEnemyAttack>().ShootAtPlayer();
            animator.SetBool("isPatrolling", false);
            //animator.SetBool("attack", true);
            
        }
        else if(Vector3.Distance(animator.transform.position, PlayerFifi.instance.transform.position) > withinRange)
        {
            animator.SetBool("isPatrolling", true);
            animator.SetBool("isShooting", false);
        }
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
