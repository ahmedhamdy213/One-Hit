using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
     EnemyWeapon Damage;
    Transform player;
    Rigidbody2D Rb;
    EnemyFlip Boss;
    public float AttackRange = 3f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Rb = animator.GetComponent<Rigidbody2D>();
        Boss = animator.GetComponent<EnemyFlip>();
        Damage = animator.GetComponent<EnemyWeapon>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.LookAtPlayer();
        
        if (Damage.GroundCeck)
        {
            
            Vector2 target = new Vector2(player.position.x, Rb.position.y);
            Vector2 NewPos = Vector2.MoveTowards(Rb.position, target, speed * Time.fixedDeltaTime);
            Rb.MovePosition(NewPos);

            if (Vector2.Distance(player.position, Rb.position) <= AttackRange)
            {
                animator.SetTrigger("Attack");
                Damage.Attack();
            }
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
    

}
