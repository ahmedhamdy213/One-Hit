using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;
    public Rigidbody2D Player;
    

    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            
            Player.bodyType = RigidbodyType2D.Static;
            GetComponent<Animator>().SetTrigger("DIED");
            Invoke("Die", 1);
        }
    }

    void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
