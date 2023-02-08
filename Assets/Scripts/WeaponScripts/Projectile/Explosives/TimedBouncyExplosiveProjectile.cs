using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBouncyExplosiveProjectile : ExplosiveProjectile 
{
    public float timer;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(timer);
        if (!exploded)
        {
            StartCoroutine(Explode());
        }
    }


    void OnCollisionEnter(Collision other)
    {

        
            EnemyScript e = other.collider.GetComponent<EnemyScript>();
            if (e != null)
            {
                e.ChangeHealth(contactDamage);
                StartCoroutine(Explode());
            }
        

       
    }
}
