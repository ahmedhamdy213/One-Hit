using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public Animator Anim;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int AttackDamage = 100;
    public float AttackRate = 2f;
    public float NextAttackTime = 0f;

    public float AttackRange { get => attackRange; set => attackRange = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ATK();
                NextAttackTime = Time.time + 1 / AttackRate;
            }
        }
    }


    void ATK()
    {
        Anim.SetTrigger("Hit");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(AttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)

            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
