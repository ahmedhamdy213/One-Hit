using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public Transform player;

    

    public void LookAtPlayer()
    {
        

        if (transform.position.x > player.position.x )
        {
            transform.rotation= Quaternion.Euler(0,0,0);    
            
        }
        else if (transform.position.x < player.position.x )
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
