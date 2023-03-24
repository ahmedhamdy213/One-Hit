using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 20;
    public int CurrentHealth;
    public Animator Anim;
    [SerializeField] AudioSource DieFx;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Health;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;

        if (CurrentHealth <= 0)
        {
            DieFx.Play();
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Died");
        Anim.SetBool("Dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
