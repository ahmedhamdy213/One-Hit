using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEnemy : MonoBehaviour
{
    public Rigidbody2D Player;
    [SerializeField] AudioSource DieSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            DieSound.Play();
            Die();
        }
    }

    private void Die()
    {

        Player.bodyType = RigidbodyType2D.Static;
        GetComponent<Animator>().SetTrigger("Dead");
    }

}
